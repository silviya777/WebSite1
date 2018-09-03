using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


public partial class Index : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        IspuniStranicu();
    }

    private void IspuniStranicu()
    { 
        // uzmi listu svih proizvoda u bazi
        ProizvodiModel proizvodModel = new ProizvodiModel();
        List<Proizvodi> proizvodi = proizvodModel.UzmiSveProizvode();

        // provjerava dali proizvodi postoje u bazi
        if (proizvodi != null)
        {
            // kreira novi Panel sa slikom i 2 labele za svaki proizvod
            foreach (Proizvodi proizvod in proizvodi)
            {
                Panel proizvodPanel = new Panel();
                ImageButton slikaGumb = new ImageButton();
                Label lblNaziv = new Label();
                Label lblCijena = new Label();

                //postavi svojstva - childcontrol - samo kontrole u gore objektima i izravna djeca
                slikaGumb.ImageUrl = "~/Slike/Proizvodi/" + proizvod.Slika;
                slikaGumb.CssClass = "proizvodSlika";
                slikaGumb.PostBackUrl = "~/Stranice/Proizvod.aspx?id=" + proizvod.Id;

                lblNaziv.Text = proizvod.Naziv;
                lblCijena.CssClass = "proizvodNaziv";

                lblCijena.Text = proizvod.Cijena + " kn " ;
                lblCijena.CssClass = "proizvodCijena";

                //postavi za Panel - childcontrol - (slikaGumb je control child)
                proizvodPanel.Controls.Add(slikaGumb);
                proizvodPanel.Controls.Add(new Literal { Text = "<br />" }); //nova instanca kontrole klase sa tekstom
                proizvodPanel.Controls.Add(lblNaziv);
                proizvodPanel.Controls.Add(new Literal { Text = "<br />" }); 
                proizvodPanel.Controls.Add(lblCijena);

                // dodaje dinamički Panel na statički Panel
                pnlProizvodi.Controls.Add(proizvodPanel);




            }

        }
        else
        {     //nema pronađenih proizvoda
            pnlProizvodi.Controls.Add(new Literal { Text = " Nisu pronađeni proizvodi! " });

        
        }
    }
    
}