using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.AspNet.Identity; // ZA KOŠARICU - string korisnikID

public partial class MasterPage : System.Web.UI.MasterPage
{
    protected void Page_Load(object sender, EventArgs e)
    {
        var korisnik = Context.User.Identity;  //Vraća ID od trenutno prijavljenog korisnika

        if (korisnik.IsAuthenticated) //dali je korisnik prijavljen
        {
            lnkPrijava.Visible = false; //kada je prijavljen link prijava se ne vidi
            lnkRegistracija.Visible = false;

            lnkOdjava.Visible = true;
            litStatus.Visible = true;

            // na mjesto pokraj imena logiranog korisnika ispisuje se broj stavki iz košarica
            KosaricaModel model = new KosaricaModel();
            string korisnikID = HttpContext.Current.User.Identity.GetUserId();
            litStatus.Text = string.Format("{0}, ({1})", Context.User.Identity.Name, model.UzmiBrojNarudzbi(korisnikID));

        }
        else
        {
            lnkPrijava.Visible = true;
            lnkRegistracija.Visible = true;

            lnkOdjava.Visible = false;
            litStatus.Visible = false;
        
        }
    }
    protected void lnkOdjava_Click(object sender, EventArgs e)
    {
        var autentifikacija = HttpContext.Current.GetOwinContext().Authentication;
        autentifikacija.SignOut();

        Response.Redirect("~/Index.aspx");
    }
}
