using Sismuni.Dominio.Entidad.Transparencia;
using Sismuni.Infraestructura.Data.Base;
using Sismuni.Infraestructura.Data.Modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sismuni.Infraestructura.Data.Repositorios.Transparencia.GestionExpediente
{
    public interface IGNTExpedienteRepositorio : IRepositorio<Expediente>
    {
        List<ExpedienteVob> BuscarExpedientes();
        ExpedienteVob BuscarExpedienteporId(long id);
        int AgregarExpediente(ExpedienteVob expediente);
        int ModificarExpediente(ExpedienteVob expediente);
    }
}
