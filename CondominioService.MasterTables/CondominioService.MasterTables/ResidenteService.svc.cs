using CondominioService.MasterTables.Dominio;
using CondominioService.MasterTables.Persistencia;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;

namespace CondominioService.MasterTables
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "ResidenteService" in code, svc and config file together.
    // NOTE: In order to launch WCF Test Client for testing this service, please select ResidenteService.svc or ResidenteService.svc.cs at the Solution Explorer and start debugging.
    public class ResidenteService : IResidenteService
    {
        private ResidenteDAO residenteDAO = null;
        private ResidenteDAO ResidenteDAO 
        {
            get 
            {
                if (residenteDAO == null)
                    residenteDAO = new ResidenteDAO();
                return residenteDAO;
            }
        }

        public Residente CrearResidente(Residente residente)
        {
            if ("70517084".Equals(residente.NroDocumento))
            { 
                throw new FaultException<RepetidoException>(
                    new RepetidoException()
                    {
                        Codigo = "01",
                        Mensaje = "Residente ya existe"
                    },
                    new FaultReason("Validación de negocio")
                    );
            }
            Residente residenteACrear = new Residente()
            {
                TipoDocumento = residente.TipoDocumento,
                NroDocumento = residente.NroDocumento,
                Nombres = residente.Nombres,
                ApellidoMaterno = residente.ApellidoMaterno,
                ApellidoPaterno = residente.ApellidoPaterno,
                Correo = residente.Correo,
                Estado = residente.Estado,
                Sexo = residente.Sexo,
                FechaNacimiento = residente.FechaNacimiento,
                Telefono = residente.Telefono,
                Celular = residente.Celular,
                UsuarioCreacion = residente.UsuarioCreacion,
                FechaCreacion = residente.FechaCreacion,
                FechaModificacion = residente.FechaModificacion
            };
            return ResidenteDAO.Crear(residenteACrear) ; 
        }

        public Residente ObtenerResidente(int codigo)
        {
            return ResidenteDAO.Obtener(codigo);
        }

        public Residente ModificarResidente(Residente residente)
        {
            Residente residenteAModificar = new Residente()
            {
                Codigo = residente.Codigo,
                TipoDocumento = residente.TipoDocumento,
                NroDocumento = residente.NroDocumento,
                Nombres = residente.Nombres,
                ApellidoMaterno = residente.ApellidoMaterno,
                ApellidoPaterno = residente.ApellidoPaterno,
                Correo = residente.Correo,
                Estado = residente.Estado,
                Sexo = residente.Sexo,
                FechaNacimiento = residente.FechaNacimiento,
                Telefono = residente.Telefono,
                Celular = residente.Celular,
                UsuarioModificacion = residente.UsuarioModificacion,
                FechaModificacion = residente.FechaModificacion,
                FechaCreacion = residente.FechaCreacion
            };
            return ResidenteDAO.Modificar(residenteAModificar); 
        }

        public void EliminarResidente(int codigo)
        {
            Residente residenteExistente = ResidenteDAO.Obtener(codigo);
            ResidenteDAO.Eliminar(residenteExistente);
        }

        public List<Residente> listarResidentes()
        {
            return ResidenteDAO.ListarTodos().ToList();
        }

        public List<Residente> buscarResidentes(string nombres, string nroDocumento)  
        {
            return ResidenteDAO.ListarResidente(nombres, nroDocumento).ToList();
        }
    }
}
