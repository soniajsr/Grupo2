using System.Web;
using Sismuni.Transversal.Inyeccion.Recursos;
using Microsoft.Practices.Unity;
using System;
using System.Runtime.Remoting.Messaging;
using System.ServiceModel;
using System.Web;

namespace Sismuni.Transversal.Injeccion
{
    sealed class CicloVidaPorPeticion : LifetimeManager
    {
        #region CLASE ANIDADA

        /// <summary>
        /// Extensión personalizada para el ámbito OperationContext.
        /// </summary>
        public class ContainerExtension : IExtension<OperationContext>
        {
            #region IMPLEMENTACIÓN IExtension<OperationContext> - Propiedades

            /// <summary>
            /// Variable que almacena el objeto OperationContext.
            /// </summary>
            public object Value { get; set; }

            #endregion

            #region IMPLEMENTACIÓN IExtension<OperationContext> - Métodos

            /// <summary>
            /// Adjuntar un contexto de operación.
            /// </summary>
            /// <param name="owner"></param>
            public void Attach(OperationContext owner)
            {

            }

            /// <summary>
            /// Separa un contexto de operación.
            /// </summary>
            /// <param name="owner"></param>
            public void Detach(OperationContext owner)
            {

            }

            #endregion
        }

        #endregion

        #region PROPIEDADES

        /// <summary>
        /// Identificador asignado al contexto.
        /// </summary>
        private Guid _key;

        #endregion

        #region CONSTRUCTOR

        /// <summary>
        /// Constructor por defecto.
        /// </summary>
        public CicloVidaPorPeticion() : this(Guid.NewGuid()) { }

        /// <summary>
        ///  Constructor
        /// </summary>
        /// <param name="key">Clave para resolver el CicloVidaLarga.</param>
        CicloVidaPorPeticion(Guid key)
        {
            if (key == Guid.Empty)
                throw new ArgumentException(Mensajes.Excepcion_KeyCicloVidaLargoNulo);

            _key = key;
        }

        #endregion

        #region METODOS

        /// <summary>
        /// Obtiene el valor del contexto.
        /// </summary>
        /// <returns>Contexto actual.</returns>
        public override object GetValue()
        {
            object result = null;

            //Get object depending on  execution environment ( WCF without HttpContext,HttpContext or CallContext)
            if (OperationContext.Current != null)
            {
                //WCF without HttpContext environment
                var containerExtension = OperationContext.Current.Extensions.Find<ContainerExtension>();
                if (containerExtension != null)
                {
                    result = containerExtension.Value;
                }
            }
            else if (HttpContext.Current != null)
            {
                //HttpContext avaiable ( ASP.NET ..)
                if (HttpContext.Current.Items[_key.ToString()] != null)
                    result = HttpContext.Current.Items[_key.ToString()];
            }
            else
            {
                //Not in WCF or ASP.NET Environment, UnitTesting, WinForms, WPF etc.
                result = CallContext.GetData(_key.ToString());
            }

            return result;
        }

        /// <summary>
        /// Remueve el contexto actual.
        /// </summary>
        public override void RemoveValue()
        {
            if (OperationContext.Current != null)
            {
                //WCF without HttpContext environment
                var containerExtension = OperationContext.Current.Extensions.Find<ContainerExtension>();
                if (containerExtension != null)
                    OperationContext.Current.Extensions.Remove(containerExtension);

            }
            else if (HttpContext.Current != null)
            {
                //HttpContext avaiable ( ASP.NET ..)
                if (HttpContext.Current.Items[_key.ToString()] != null)
                    HttpContext.Current.Items[_key.ToString()] = null;
            }
            else
            {
                //Not in WCF or ASP.NET Environment, UnitTesting, WinForms, WPF etc.
                CallContext.FreeNamedDataSlot(_key.ToString());
            }
        }

        /// <summary>
        /// Establece el valor de contexto.
        /// </summary>
        /// <param name="newValue"></param>
        public override void SetValue(object newValue)
        {
            if (OperationContext.Current != null)
            {
                //WCF without HttpContext environment
                var containerExtension = OperationContext.Current.Extensions.Find<ContainerExtension>();
                if (containerExtension == null)
                {
                    containerExtension = new ContainerExtension()
                    {
                        Value = newValue
                    };

                    OperationContext.Current.Extensions.Add(containerExtension);
                }
            }
            else if (HttpContext.Current != null)
            {
                //HttpContext avaiable ( ASP.NET ..)
                if (HttpContext.Current.Items[_key.ToString()] == null)
                    HttpContext.Current.Items[_key.ToString()] = newValue;
            }
            else
            {
                //Not in WCF or ASP.NET Environment, UnitTesting, WinForms, WPF etc.
                CallContext.SetData(_key.ToString(), newValue);
            }
        }

        #endregion
    }
}
