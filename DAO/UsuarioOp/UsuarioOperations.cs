using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Model.Token;
namespace DAO.UsuarioOp
{
    public class UsuarioOperations : IUsuarioOperations
    {
        private readonly bloodbog_bdEntities _context;
        public UsuarioOperations(bloodbog_bdEntities context)
        {
            this._context = context;
            this._context.Configuration.ProxyCreationEnabled = false;
        }

        public Usuario validateUser(Usuario usuario)
        {
            return _context.Usuario.Where(
                               u => u.IdTipoDocumento == usuario.IdTipoDocumento &
                                    u.NumeroDocumento == usuario.NumeroDocumento &
                                    u.Estado == true
                               ).FirstOrDefault();

        }
        public int create(Usuario usuario)
        {
            int existeUsuario = _context.Usuario.Where(
                                u => u.IdTipoDocumento == usuario.IdTipoDocumento &
                                     u.NumeroDocumento == usuario.NumeroDocumento
                                ).ToList().Count();
            int result = 0;
            if (existeUsuario == 0)
            {
                _context.Usuario.Add(usuario);
                result = _context.SaveChanges();
            }
            return result;
        }
        public Usuario getUserByNumDocument(string numDocumento, int tipoDocumento)
        {
            return _context.Usuario.Where(
                                u => u.IdTipoDocumento == tipoDocumento &
                                     u.NumeroDocumento == numDocumento
                ).FirstOrDefault();
        }

        public int updatePassword(int idUsuario, string password)
        {
            dynamic user = _context.Usuario.Where(
                            u => u.IdUsuario == idUsuario).FirstOrDefault();
            user.HashContrasena = password;
            return _context.SaveChanges();
        }

        public Usuario getUsuarioById(int idUsuario)
        {
            return _context.Usuario.Where(
                            u => u.IdUsuario == idUsuario).FirstOrDefault();
        }

        public int updateUsuario(int idUsuario, Usuario usuario)
        {
            dynamic user = _context.Usuario.Where(
                            u => u.IdUsuario == idUsuario).FirstOrDefault();
            user.Nombres = usuario.Nombres;
            user.PrimerApellido = usuario.PrimerApellido;
            user.CorreoElectronico = usuario.CorreoElectronico;
            user.Peso = usuario.Peso;
            user.FechaNacimiento = usuario.FechaNacimiento;


            return _context.SaveChanges();
        }
        public List<Usuario> getEntidades()
        {
            return _context.Usuario.Where(
                u => u.IdRol == 3
                )
                //.Select(u => new Usuario {
                //    Nombres = u.Nombres ,
                //    IdUsuario=u.IdUsuario})
                .ToList();
        }
    }
}
