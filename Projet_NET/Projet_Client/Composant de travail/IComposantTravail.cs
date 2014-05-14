using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Projet_Client.Composant_de_travail
{
    interface IComposantTravail
    {
        MessageSerializable.Message Exec(MessageSerializable.Message msg);
    }
}
