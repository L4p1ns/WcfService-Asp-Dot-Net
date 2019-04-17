using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using WcfService.Model;

namespace WcfService
{
    // REMARQUE : vous pouvez utiliser la commande Renommer du menu Refactoriser pour changer le nom de classe "Service1" dans le code, le fichier svc et le fichier de configuration.
    // REMARQUE : pour lancer le client test WCF afin de tester ce service, sélectionnez Service1.svc ou Service1.svc.cs dans l'Explorateur de solutions et démarrez le débogage.
    public class Service1 : IService1

    {
        bdFadiouEntities db = new bdFadiouEntities();

        public bool AjouterChambre(Chambres ch)
        {
            bool rep = false;
            try
            {
                db.Chambres.Add(ch);
                db.SaveChanges();
                rep = true;
            }catch(Exception ex)
            {

            }
            return rep;
        }

        public bool SupprimerChambre(int id)
        {
            var del = db.Chambres.Find(id);
            db.Chambres.Remove(del);
            db.SaveChanges();
            throw new NotImplementedException();
        }

        public bool EditerChambre(Chambres ch)
        {
            bool rep = false;
            try
            {
                var i = db.Chambres.Find(ch.idCh);
                i.codeCh = ch.codeCh;
                i.libelle = ch.libelle;
                db.SaveChanges();

            }catch(Exception ex)
            {

            }
            return rep;
                
        }
        public List<Chambres> ListerChambres()
        {
            return db.Chambres.ToList();
            throw new NotImplementedException();
        }

        public string GetData(int value)
        {
            return string.Format("You entered: {0}", value);
        }

        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }

    
    }
}
