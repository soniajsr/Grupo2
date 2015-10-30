using Sismuni.Dominio.Entidad.General;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using Sismuni.Presentacion.Web.Resources;

namespace Sismuni.Presentacion.Web.Helpers.Extensiones
{
    public static class Util
    {
        #region LISTAS TT

        /// <summary>
        /// Convierte un lista de elementos en un lista seleccionable para la pagina
        /// </summary>
        /// <param name="origenTT"></param>
        /// <returns></returns>
        public static BindingList<SelectListItem> LlenarTT(this IEnumerable<ElementoVob> origenTT)
        {
            if (origenTT == null) return null;
            var destinyTT = new BindingList<SelectListItem>();

            foreach (ElementoVob it in origenTT)
            {
                destinyTT.Add(new SelectListItem
                {
                    Value = it.Valor,
                    Text = it.Texto,
                    Selected = it.Seleccionado
                });
            }
            return destinyTT;
        }

        /// <summary>
        /// LlenarElemenato
        /// </summary>
        /// <param name="origen"></param>
        /// <returns></returns>
        public static IEnumerable<string> LlenarElemenato(this IEnumerable<ElementoVob> origen)
        {
            if (origen == null) return null;
            var destinyTT = new List<string>();

            foreach (ElementoVob it in origen)
            {
                destinyTT.Add(it.Valor);
            }
            return destinyTT;
        }

        #endregion

        #region Files

        /// <summary>
        /// NombreArchivoSinExtension
        /// </summary>
        /// <param name="nombre">nombre</param>
        /// <returns>Nombre sin extension</returns>
        public static string NombreArchivoSinExtension(this string nombre)
        {
            var lastBackslash = nombre.LastIndexOf(@"\");
            var lastPoint = nombre.LastIndexOf(".");
            if (lastBackslash == -1)
                return lastPoint == -1 ? nombre : nombre.Substring(0, lastPoint);
            else
                return lastPoint == -1 ? nombre.Substring(lastBackslash + 1) : nombre.Substring(lastBackslash + 1, lastPoint - lastBackslash - 1);
        }

        /// <summary>
        /// ExtensionArchivo
        /// </summary>
        /// <param name="nombre">Nombre</param>
        /// <returns>Extension del archivo</returns>
        public static string ExtensionArchivo(this string nombre)
        {
            var lastPoint = nombre.LastIndexOf(".");
            return lastPoint == -1 ? "" : nombre.Substring(lastPoint + 1, nombre.Length - lastPoint - 1);
        }

        #endregion

        #region ARCHIVO

        /// <summary>
        /// SizeToKMB
        /// </summary>
        /// <param name="tamanio">tamanio</param>
        /// <returns>Número de bytes</returns>
        public static string SizeToKMB(int tamanio)
        {
            if (tamanio < 1024)
                return tamanio + " B";
            else if (tamanio < 1024 * 1024)
                return (tamanio / 1024) + " KB";
            else if (tamanio < 1024 * 1024 * 1024)
                return (tamanio / (1024 * 1024)) + " MB";

            return "0 B";
        }

        /// <summary>
        /// Devuelve numero de Kb
        /// </summary>
        /// <param name="tamanio">int</param>
        /// <returns>string</returns>
        public static decimal SizeToKb(int tamanio)
        {
            return System.Math.Round(((decimal)tamanio / 1024), 2);
        }

        /// <summary>
        /// IconExtension
        /// </summary>
        /// <param name="ext">ext</param>
        /// <returns>Clase del icono a mostrar</returns>
        public static string IconExtension(string ext)
        {
            var icon = string.Empty;
            ext = ext.ToLower();

            switch (ext)
            {
                case "xls":
                case "xlsx":
                case "csv":
                    icon = Iconos.Icon16_Doc_Excel;
                    break;
                case "doc":
                case "docx":
                    icon = Iconos.Icon16_Doc_Word;
                    break;
                case "pdf":
                    icon = Iconos.Icon16_Doc_Pdf;
                    break;
                case "rar":
                case "zip":
                    icon = Iconos.Icon16_Doc_Zip;
                    break;
                case "jpg":
                case "gif":
                case "png":
                case "tif":
                case "jpeg":
                case "bmp":
                case "jpe":
                case "ico":
                    icon = Iconos.Icon16_Doc_Imgs;
                    break;
                default:
                    icon = Iconos.Icon16_Doc_Desconocido;
                    break;
            }

            return icon;
        }

        /// <summary>
        /// ContentType
        /// </summary>
        /// <param name="ext">extensión de archivo</param>
        /// <returns>content type</returns>
        public static string ContentTypeExtension(this string ext)
        {
            var contenttype = string.Empty;
            ext = ext.ToLower();

            switch (ext)
            {
                case "xls":
                    contenttype = ContentType.CT_Excel; break;
                case "xlsx":
                    contenttype = ContentType.CT_ExcelX; break;
                case "csv":
                    contenttype = ContentType.CT_Csv; break;
                case "doc":
                    contenttype = ContentType.CT_Word; break;
                case "docx":
                    contenttype = ContentType.CT_WordX; break;
                case "pdf":
                    contenttype = ContentType.CT_Pdf; break;
                case "rar":
                    contenttype = ContentType.CT_Rar; break;
                case "zip":
                    contenttype = ContentType.CT_Zip; break;
                case "jpg":
                case "jpe":
                case "jpeg":
                    contenttype = ContentType.CT_Jpg; break;
                case "gif":
                    contenttype = ContentType.CT_Gif; break;
                case "png":
                    contenttype = ContentType.CT_Png; break;
                case "tif":
                case "tifd":
                    contenttype = ContentType.CT_Tif; break;
                case "bmp":
                    contenttype = ContentType.CT_Bmp; break;
                case "ico":
                    contenttype = ContentType.CT_Icon; break;
                case "txt":
                    contenttype = ContentType.CT_Text; break;
                default:
                    contenttype = ContentType.CT_Desconocido; break;
            }

            return contenttype;
        }

        #endregion

        #region CONVERTIR LISTA A DATATABLE

        /// <summary>
        /// ConvertToDataTable
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="data"></param>
        /// <param name="nombreTabla"></param>
        /// <returns></returns>
        public static DataTable ConvertToDataTable<T>(IList<T> data, string nombreTabla)
        {
            PropertyDescriptorCollection properties =
               TypeDescriptor.GetProperties(typeof(T));
            DataTable table = new DataTable(nombreTabla);
            foreach (PropertyDescriptor prop in properties)
                table.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            foreach (T item in data)
            {
                DataRow row = table.NewRow();
                foreach (PropertyDescriptor prop in properties)
                    row[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                table.Rows.Add(row);
            }

            if (data.Count == 0)
            {
                DataRow row = table.NewRow();
                table.Rows.Add(row);
            }

            return table;
        }

        #endregion

        #region CONVERTIR IMAGEN A ARRAY DE BYTE

        public static Byte[] CargarImagen(string rutaArchivo)
        {
            if (rutaArchivo != "")
            {
                try
                {
                    FileStream Archivo = new FileStream(rutaArchivo, FileMode.Open, FileAccess.Read);//Creo el archivo
                    BinaryReader binRead = new BinaryReader(Archivo);//Cargo el Archivo en modo binario

                    Byte[] imagenEnBytes = new Byte[(Int64)Archivo.Length]; //Creo un Array de Bytes donde guardare la imagen

                    binRead.Read(imagenEnBytes, 0, (int)Archivo.Length);//Cargo la imagen en el array de Bytes
                    binRead.Close();
                    Archivo.Close();
                    return imagenEnBytes;//Devuelvo la imagen convertida en un array de bytes
                }
                catch
                {
                    return new Byte[0];
                }
            }

            return new byte[0];
        }

        #endregion
    }
}