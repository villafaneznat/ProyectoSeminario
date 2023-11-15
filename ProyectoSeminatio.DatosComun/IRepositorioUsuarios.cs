using ProyectoSeminario.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProyectoSeminatio.DatosComun
{
    public interface IRepositorioUsuarios
    {
        bool Exist(Usuario user);
        List<Usuario> GetUsuarios();
        Dictionary<Permisos, bool> ObtenerPermisosDeUsuario(Usuario user, TipoEntidad entidad);
    }
}
