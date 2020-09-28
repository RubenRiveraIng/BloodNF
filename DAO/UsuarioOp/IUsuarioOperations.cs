using System;
using System.Collections.Generic;
using System.Text;
using Model.Token;
namespace DAO.UsuarioOp
{
    public interface IUsuarioOperations
    {
        Usuario validateUser(Usuario usuario);
        int create(Usuario usuario);
	    Usuario getUserByNumDocument(string numDocumento, int tipoDocumento);

        int updatePassword(int idUsuario, string password);

        Usuario getUsuarioById(int idUsuario);
        int updateUsuario(int idUsuario,Usuario usuario);

        List<Usuario> getEntidades();

    }
}
