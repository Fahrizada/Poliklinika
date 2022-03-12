using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Poliklinika.Model;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace PoliklinikaAPI.Data
{
    public class Data
    {
        public static void Seed(DBContext context, UserManager<User> userManager, RoleManager<Role> roleManager, IWebHostEnvironment host)
        {

            if (context.Database.CanConnect())
                return;

            context.Database.Migrate();

            #region Roles
            var AdminRole = new Role { Name = "Admin" };
            var DoktorRole = new Role { Name = "Doktor" };
            var TehnicarRole = new Role { Name = "Tehnicar" };
            var KorisnkRole = new Role { Name = "Korisnik" };

            roleManager.CreateAsync(AdminRole).GetAwaiter().GetResult();
            roleManager.CreateAsync(DoktorRole).GetAwaiter().GetResult();
            roleManager.CreateAsync(TehnicarRole).GetAwaiter().GetResult();
            roleManager.CreateAsync(KorisnkRole).GetAwaiter().GetResult();
            #endregion

            #region Odjeli
            var folderPath = host.ContentRootPath;

            var odjeli = new List<Odjel>()
            {

                new Odjel{
                    Naziv = "Stomatologija",
                    Opis = "Odjel stomatologije"
                },

                new Odjel{
                    Naziv = "Urologija",
                    Opis = "Odjel Urologije"
                },

                new Odjel{
                    Naziv = "Ginekologija",
                    Opis = "Odjel ginekologije"
                },

                new Odjel{
                    Naziv = "Psihijatrija",
                    Opis = "Odjel psihijatrije"
                },

                new Odjel{
                    Naziv = "Kardiologija",
                    Opis = "Odjel kardiologije"
                },

                new Odjel{
                    Naziv = "Neurologija",
                    Opis = "Odjel neurologije"
                },

                new Odjel{
                    Naziv = "Dermatologija",
                    Opis = "Odjel dermatologije"
                },

                new Odjel{
                    Naziv = "Otorinolaringologija",
                    Opis = "Odjel otorinolaringologije"
                },
            };

            foreach (var o in odjeli)
            {
                context.Odjel.Add(o);
            }
            context.SaveChanges();
            #endregion

            #region Admin
            var admin = new Admin
            {
                Ime = "Admin",
                Prezime = "Admin",
                Email = "admin@hotmail.com",
                UserName = "admin@hotmail.com"
            };

            CreateAdmin(admin, userManager, context);
            #endregion

            #region Doktori
            var psih = context.Odjel.FirstOrDefault(x => x.Naziv == "Psihijatrija");

            var psihijatar = new Doktor
            {
                OdjelID = psih.ID,
                Ime = "Ahmed",
                Prezime = "Pajevic",
                Email = "ahmed@hotmail.com",
                Spol = "M",
                UserName = "ahmed@hotmail.com",
                BrojRadneKnjizice = "123456",
                Specijalizacija = "Psihijatrija",
                SubSpecijalizacija = "Socijalna Psihijatrija"
            };

             CreateDoktor(psihijatar, userManager, context);

            var stom = context.Odjel.FirstOrDefault(x => x.Naziv == "Stomatologija");

            var zubar = new Doktor
            {
                OdjelID = stom.ID,
                Ime = "Muhamed",
                Prezime = "Karic",
                Email = "muhamed@hotmail.com",
                Spol = "M",
                UserName = "muhamed@hotmail.com",
                BrojRadneKnjizice = "654321",
                Specijalizacija = "Stomatologija",
            };

             CreateDoktor(zubar, userManager, context);

            var uro = context.Odjel.FirstOrDefault(x => x.Naziv == "Urologija");

            var urolog = new Doktor
            {
                OdjelID = uro.ID,
                Ime = "Mustafa",
                Prezime = "Bazardzanovic",
                Email = "mustafa@hotmail.com",
                Spol = "M",
                UserName = "mustafa@hotmail.com",
                BrojRadneKnjizice = "123321",
                Specijalizacija = "Urologija",
            };

             CreateDoktor(urolog, userManager, context);

            var gine = context.Odjel.FirstOrDefault(x => x.Naziv == "Ginekologija");

            var ginekolog = new Doktor
            {
                OdjelID = gine.ID,
                Ime = "Seada",
                Prezime = "Hajdarevic",
                Email = "seada@hotmail.com",
                Spol = "Ž",
                UserName = "seada@hotmail.com",
                BrojRadneKnjizice = "321123",
                Specijalizacija = "Ginekologija",
            };

             CreateDoktor(ginekolog, userManager, context);

            var kardio = context.Odjel.FirstOrDefault(x => x.Naziv == "Kardiologija");

            var kardiolog = new Doktor
            {
                OdjelID = kardio.ID,
                Ime = "Emir",
                Prezime = "Kabil",
                Email = "emir@hotmail.com",
                Spol = "M",
                UserName = "emir@hotmail.com",
                BrojRadneKnjizice = "121212",
                Specijalizacija = "Kardiologija",
            };

             CreateDoktor(kardiolog, userManager, context);

            var neuro = context.Odjel.FirstOrDefault(x => x.Naziv == "Neurologija");

            var neurolog = new Doktor
            {
                OdjelID = neuro.ID,
                Ime = "Osman",
                Prezime = "Sinanovic",
                Email = "osman@hotmail.com",
                Spol = "M",
                UserName = "osman@hotmail.com",
                BrojRadneKnjizice = "212121",
                Specijalizacija = "Neurologija",
            };

             CreateDoktor(neurolog, userManager, context);

            var derma = context.Odjel.FirstOrDefault(x => x.Naziv == "Dermatologija");

            var dermatolog = new Doktor
            {
                OdjelID = derma.ID,
                Ime = "Senada",
                Prezime = "Resic",
                Email = "senada@hotmail.com",
                Spol = "Ž",
                UserName = "senada@hotmail.com",
                BrojRadneKnjizice = "111111",
                Specijalizacija = "Dermatologija",
            };

             CreateDoktor(dermatolog, userManager, context);

            var otorina = context.Odjel.FirstOrDefault(x => x.Naziv == "Otorinolaringologija");

            var otorinolaringolog = new Doktor
            {
                OdjelID = otorina.ID,
                Ime = "Dervis",
                Prezime = "Hajdarovic",
                Email = "dervis@hotmail.com",
                Spol = "M",
                UserName = "dervis@hotmail.com",
                BrojRadneKnjizice = "333333",
                Specijalizacija = "Otorinolaringologija",
            };

             CreateDoktor(otorinolaringolog, userManager, context);

            #endregion

            #region Tehnicari

            var tehnicari = new List<Tehnicar>() {
                new Tehnicar
                {
                Ime = "Faruk",
                Prezime = "Smajic",
                Email = "faruk@hotmail.com",
                Spol = "M",
                UserName = "faruk@hotmail.com",
                BrojRadneKnjizice = "232345",
                StrucnaSprema = "SSS"
                },

                new Tehnicar{
                     Ime = "Mirza",
                    Prezime = "Babajic",
                    Email = "mirza@hotmail.com",
                    Spol = "M",
                    UserName = "mirza@hotmail.com",
                    BrojRadneKnjizice = "666654",
                    StrucnaSprema = "SSS"
                },

                new Tehnicar{
                     Ime = "Amra",
                    Prezime = "Spahic",
                    Email = "amra@hotmail.com",
                    Spol = "Ž",
                    UserName = "amra@hotmail.com",
                    BrojRadneKnjizice = "668654",
                    StrucnaSprema = "SSS"
                },

                 new Tehnicar{
                     Ime = "Mia",
                    Prezime = "Turbic",
                    Email = "mia@hotmail.com",
                    Spol = "Ž",
                    UserName = "mia@hotmail.com",
                    BrojRadneKnjizice = "968654",
                    StrucnaSprema = "SSS"
                }
            };

            foreach (var t in tehnicari)
            {
                 CreateTehnicar(t, userManager, context);
            }
            #endregion

            #region Korisnici
            var korisnik = new Korisnik
            {
                Ime = "Harun",
                Prezime = "Colic",
                BrojTelefona = "062817474",
                DatumRodjenja = new DateTime(1996, 2, 15),
                Email = "haruncolic@hotmail.com",
                UserName = "haruncolic@hotmail.com",
                KrvnaGrupa = "A+",
                Spol = "M"
            };

             CreateKorisnik(korisnik, userManager, context);

            var korisnica = new Korisnik
            {
                Ime = "Fahrizada",
                Prezime = "Zekotic",
                BrojTelefona = "06288634",
                DatumRodjenja = new DateTime(1997, 6, 28),
                Email = "fahrizada@hotmail.com",
                UserName = "fahrizada@hotmail.com",
                KrvnaGrupa = "A+",
                Spol = "Ž"
            };

             CreateKorisnik(korisnica, userManager, context);

            #endregion

            #region Pregledi
            var pregledi = new List<Pregled>()
            {
                new Pregled
                {
                    Datum = DateTime.Now.Date + new TimeSpan(10, 0, 0),
                    DoktorID = psihijatar.Id,
                    KorisnikID = korisnik.Id,
                    OdjelID = psih.ID,
                    TehnicarID = context.Tehnicar.First().Id
                },

                new Pregled
                {
                    Datum = DateTime.Now.Date + new TimeSpan(10, 0, 0),
                    DoktorID = psihijatar.Id,
                    KorisnikID = korisnik.Id,
                    OdjelID = psih.ID,
                    TehnicarID = context.Tehnicar.OrderBy(x => x.Id).Last().Id
                },

                new Pregled
                {
                    Datum = DateTime.Now.Date + new TimeSpan(10, 0, 0),
                    KorisnikID = korisnik.Id,
                    OdjelID = psih.ID,
                },

                new Pregled
                {
                    Datum = DateTime.Now.Date + new TimeSpan(10, 0, 0),
                    DoktorID = zubar.Id,
                    KorisnikID = korisnica.Id,
                    OdjelID = stom.ID,
                    TehnicarID = context.Tehnicar.First().Id
                },

                new Pregled
                {
                    Datum = DateTime.Now.Date + new TimeSpan(10, 0, 0),
                    DoktorID = zubar.Id,
                    KorisnikID = korisnica.Id,
                    OdjelID = stom.ID,
                    TehnicarID = context.Tehnicar.OrderBy(x => x.Id).Last().Id
                },
                new Pregled
                {
                    Datum = DateTime.Now.Date + new TimeSpan(10, 0, 0),
                    KorisnikID = korisnica.Id,
                    OdjelID = stom.ID,
                }
            };

            foreach (var p in pregledi)
            {
                context.Pregled.Add(p);
            }
            context.SaveChanges();

            #endregion

            #region Uplate

            var korisnikPregledi = context.Pregled.Where(x => x.KorisnikID == korisnik.Id).ToList();
            var korisnicaPregledi = context.Pregled.Where(x => x.KorisnikID == korisnica.Id).ToList();

            var uplate = new List<Uplata>()
            {
                new Uplata
                {
                    DatumUplate = DateTime.Now,
                    PregledID = korisnikPregledi[0].ID
                },

                new Uplata
                {
                    DatumUplate = DateTime.Now,
                    PregledID = korisnikPregledi[1].ID
                },

                new Uplata
                {
                    DatumUplate = DateTime.Now,
                    PregledID = korisnikPregledi[2].ID
                },

                new Uplata
                {
                    DatumUplate = DateTime.Now,
                    PregledID = korisnikPregledi[2].ID
                },

                 new Uplata
                {
                    DatumUplate = DateTime.Now,
                    PregledID = korisnicaPregledi[0].ID
                },

                new Uplata
                {
                    DatumUplate = DateTime.Now,
                    PregledID = korisnicaPregledi[1].ID
                },

                new Uplata
                {
                    DatumUplate = DateTime.Now,
                    PregledID = korisnicaPregledi[2].ID
                },

                new Uplata
                {
                    DatumUplate = DateTime.Now,
                    PregledID = korisnicaPregledi[2].ID
                },
            };

            foreach (var u in uplate)
            {
                context.Uplata.Add(u);
            }
            context.SaveChanges();

            #endregion

            #region Nalazi

            var nalazi = new List<Nalaz>()
            {
                new Nalaz
                {
                    Opis = "Opis nalaza",
                    PregledID = korisnikPregledi[1].ID,
                },

                new Nalaz
                {
                    Opis = "Opis nalaza",
                    PregledID = korisnikPregledi[2].ID,
                },

                new Nalaz
                {
                    Opis = "Opis nalaza",
                    PregledID = korisnicaPregledi[1].ID,
                },

                new Nalaz
                {
                    Opis = "Opis nalaza",
                    PregledID = korisnicaPregledi[2].ID,
                },
            };

            foreach (var n in nalazi)
            {
                context.Nalaz.Add(n);
            }
            context.SaveChanges();

            #endregion

            #region Izvjestaji

            var izvjestaji = new List<Izvjestaj>()
            {
                new Izvjestaj
                {
                    PregledID = korisnikPregledi[1].ID,
                    Opis = "Opis izvjestaja"
                },

                new Izvjestaj
                {
                    PregledID = korisnikPregledi[2].ID,
                    Opis = "Opis izvjestaja"
                },

                new Izvjestaj
                {
                    PregledID = korisnicaPregledi[1].ID,
                    Opis = "Opis izvjestaja"
                },

                new Izvjestaj
                {
                    PregledID = korisnicaPregledi[2].ID,
                    Opis = "Opis izvjestaja"
                },
            };

            foreach (var i in izvjestaji)
            {
                context.Izvjestaj.Add(i);
            }
            context.SaveChanges();

            #endregion

            #region Rasporedi
            var pr = context.Pregled.Where(x => x.DoktorID != null && x.TehnicarID != null).ToList();

            foreach (var p in pr)
            {

                var rasp = new Raspored
                {
                    PregledID = p.ID,
                    TehnicarID = int.Parse(p.TehnicarID.ToString()),
                    DoktorID = int.Parse(p.DoktorID.ToString()),
                    Vrijeme = "10:00-11:00",
                    Datum = DateTime.Now.Date + new TimeSpan(0, 0, 0)
                };

                context.Raspored.Add(rasp);
            }

            context.SaveChanges();
            #endregion

            #region Obaveza

            var obaveze = new List<Obaveza>()
            {
                new Obaveza
                {
                    Datum = DateTime.Now,
                    Aktivna = true,
                    OdjelID = psih.ID,
                    OsobljeID = psihijatar.OdjelID,
                    Opis = "Opis obaveze"
                },

                new Obaveza
                {
                    Datum = DateTime.Now,
                    Aktivna = false,
                    OdjelID = psih.ID,
                    OsobljeID = psihijatar.OdjelID,
                    Opis = "Opis obaveze"
                },

                new Obaveza
                {
                    Datum = DateTime.Now,
                    Aktivna = true,
                    OdjelID = stom.ID,
                    OsobljeID = zubar.OdjelID,
                    Opis = "Opis obaveze"
                },

                new Obaveza
                {
                    Datum = DateTime.Now,
                    Aktivna = false,
                    OdjelID = stom.ID,
                    OsobljeID = zubar.OdjelID,
                    Opis = "Opis obaveze"
                },

                new Obaveza
                {
                    Datum = DateTime.Now,
                    Aktivna = true,
                    OdjelID = otorina.ID,
                    OsobljeID = otorinolaringolog.OdjelID,
                    Opis = "Opis obaveze"
                },

                new Obaveza
                {
                    Datum = DateTime.Now,
                    Aktivna = false,
                    OdjelID = otorina.ID,
                    OsobljeID = otorinolaringolog.OdjelID,
                    Opis = "Opis obaveze"
                },
            };

            foreach (var o in obaveze)
            {
                context.Obaveza.Add(o);
            }
            context.SaveChanges();

            #endregion

            #region ChatObaveze
            var chatovi = new List<ChatObaveza>()
            {
                new ChatObaveza
                {
                    ObavezaID = context.Obaveza.Where(x => x.Aktivna).ToList()[0].ID,
                    AdminID = context.Admin.First().Id,
                    OsobljeID = context.Obaveza.First().OsobljeID
                },

                new ChatObaveza
                {
                    ObavezaID = context.Obaveza.Where(x => x.Aktivna).ToList()[1].ID,
                    AdminID = context.Admin.First().Id,
                    OsobljeID = context.Obaveza.First().OsobljeID
                }
            };

            foreach (var c in chatovi)
            {
                context.ChatObaveza.Add(c);
            }
            context.SaveChanges();

            #endregion

            #region ChatPoruke

            var chatovio = context.ChatObaveza.ToList();

            for (int i = 0; i < 6; i++)
            {
                var poruka1 = new ChatPoruka
                {
                    ChatObavezaID = chatovio[0].ID,
                    OsobljeID = chatovio[0].OsobljeID,
                    Poruka = "Test poruka"
                };

                var poruka2 = new ChatPoruka
                {
                    ChatObavezaID = chatovio[0].ID,
                    OsobljeID = chatovio[0].AdminID,
                    Poruka = "Test poruka"
                };

                var poruka3 = new ChatPoruka
                {
                    ChatObavezaID = chatovio[1].ID,
                    OsobljeID = chatovio[1].OsobljeID,
                    Poruka = "Test poruka"
                };

                var poruka4 = new ChatPoruka
                {
                    ChatObavezaID = chatovio[1].ID,
                    OsobljeID = chatovio[1].AdminID,
                    Poruka = "Test poruka"
                };

                context.ChatPoruka.Add(poruka1);
                context.ChatPoruka.Add(poruka2);
                context.ChatPoruka.Add(poruka3);
                context.ChatPoruka.Add(poruka4);
            }

            context.SaveChanges();

            #endregion

        }

        #region Create Metode
        public static void CreateAdmin(Admin user, UserManager<User> userManager, DBContext context)
        {
            userManager.CreateAsync(user, "Test-123").GetAwaiter().GetResult();
            userManager.AddToRoleAsync(user, "Admin").GetAwaiter().GetResult();
        }

        public static void CreateTehnicar(Tehnicar user, UserManager<User> userManager, DBContext context)
        {
            userManager.CreateAsync(user, "Test-123").GetAwaiter().GetResult();
            userManager.AddToRoleAsync(user, "Tehnicar").GetAwaiter().GetResult();
        }

        public static void CreateDoktor(Doktor user, UserManager<User> userManager, DBContext context)
        {
            userManager.CreateAsync(user, "Test-123").GetAwaiter().GetResult();
            userManager.AddToRoleAsync(user, "Doktor").GetAwaiter().GetResult();
        }

        public static void CreateKorisnik(Korisnik user, UserManager<User> userManager, DBContext context)
        {
            userManager.CreateAsync(user, "Test-123").GetAwaiter().GetResult();
            userManager.AddToRoleAsync(user, "Korisnik").GetAwaiter().GetResult();
        }
        #endregion

        #region Create Images
        public static byte[] ImageToStream(string fileName)
        {
            MemoryStream stream = new MemoryStream();
            try
            {
                var file = File.ReadAllBytes(fileName);
                Image image = Image.FromFile(fileName);
                image.Save(stream, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch
            {
                throw;
            }

            return stream.ToArray();
        }
        #endregion
    }
}