using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LW.IO.Business.Notifications
{
    public class Notificacao
    {
        public Notificacao(string mensagem)
        {
            Mensagem = mensagem;
        }

        public string Mensagem { get; }
    }
}
