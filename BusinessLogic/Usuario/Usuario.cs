using DAO;
using DAO.UsuarioOp;
using System;
using System.Collections.Generic;
using System.Text;
using Model.Token;
using Model.Email;

namespace BusinessLogic.Usuario
{
    public class Usuario
    {
        public IUsuarioOperations _operations;
        public Usuario(bloodbog_bdEntities context)
        {
            this._operations = new UsuarioOperations(context);
        }
        public dynamic validateUser(List<string> Token, DAO.Usuario usuario)
        {
            var result = _operations.validateUser(usuario);
            var response = String.Empty;
            if (result != null)
            {
                string decrypt = Util.Decrypt.decryptMethod(result.HashContrasena);
                if (usuario.HashContrasena.Equals(decrypt))
                {
                    response = null;
                    response = Util.Token.Generate(Token[0],Token[1],Token[2],Token[3], new Claims()
                    {
                        userId = result.IdUsuario,
                        userName = result.NumeroDocumento,
                        userRole = result.IdRol.ToString()
                    });
                }
            }
            return response;
        }
        public dynamic create(DAO.Usuario usuario)
        {
            usuario.HashContrasena = Util.Encrypt.encryptMethod(usuario.HashContrasena);
            usuario.FechaNacimiento = DateTime.Parse("01/01/1900");
            usuario.Peso = 0;
            usuario.IdRol = (usuario.IdTipoDocumento == 3) ? 3 : 2;
            usuario.Estado = (usuario.IdTipoDocumento == 3) ? false : true;
            return _operations.create(usuario);
        }
        public dynamic sendMailResetPassword(string environmentUrl, List<string> Token, string numDocumento, int tipoDocumento, SendMail dataEmail)
        {
            var dataUser = _operations.getUserByNumDocument(numDocumento, tipoDocumento);
            var response = false;
            if (dataUser != null)
            {
                dataEmail.emailTo = dataUser.CorreoElectronico;
                dataEmail.nameTo = dataUser.Nombres + " " + dataUser.PrimerApellido;
                Util.SendMail mailOperations = new Util.SendMail(dataEmail);
                string newPass=mailOperations.sendMailResetPassword();
                newPass= Util.Encrypt.encryptMethod(newPass);
                response = _operations.updatePassword(dataUser.IdUsuario, newPass)==1?true:false;
            }
            return response;
        }

        public dynamic updatePassword(int idUsuario,string password)
        {
            password = Util.Encrypt.encryptMethod(password);
            return _operations.updatePassword(idUsuario, password);
        }
        public dynamic getUsuarioById(int idUsuario)
        {
            return _operations.getUsuarioById(idUsuario);
        }

        public dynamic updateUser(int idUsuario, DAO.Usuario usuario)
        {
            return _operations.updateUsuario(idUsuario,usuario);
        }
        public dynamic getEntidades()
        {
            return _operations.getEntidades();
        }
    }
}
