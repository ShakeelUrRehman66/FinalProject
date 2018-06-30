using finalproject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace finalproject.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context)
        {
            context.Database.EnsureCreated();
            // Look for any students.
            if (context.Doctors.Any())
            {
                return; // DB has been seeded
            }
            var doctors = new Doctor[]
            {
                new Doctor{Name="Carson",Email="Alexander@mail.com",Password="shakeel",CNIC="324213",Age=12,Qualification="new",Hospital="lates"},
                new Doctor{Name="Carson1",Email="new@mail.com",Password="shakeel",CNIC="324213",Age=12,Qualification="new",Hospital="lates"},
                new Doctor{Name="villa",Email="bi@mail.com",Password="shakeel",CNIC="324213",Age=12,Qualification="nedasw",Hospital="latasdes"},
                new Doctor{Name="nilla",Email="hi@mail.com",Password="shakeel",CNIC="324213",Age=12,Qualification="nedaw",Hospital="latwervces"},
                new Doctor{Name="illa",Email="mill@mail.com",Password="shakeel",CNIC="324213",Age=12,Qualification="neqdew",Hospital="laxtes"},
                new Doctor{Name="giila",Email="gill@mail.com",Password="shakeel",CNIC="324213",Age=12,Qualification="new3",Hospital="latesfwers"},
                new Doctor{Name="darson",Email="Abew@mail.com",Password="shakeel",CNIC="324213",Age=12,Qualification="new2",Hospital="laerewtes"},
                new Doctor{Name="sarson",Email="sarr@mail.com",Password="shakeel",CNIC="324213",Age=12,Qualification="new1",Hospital="lawertes"}
};
            foreach (Doctor s in doctors)
            {
                context.Doctors.Add(s);
            }
            context.SaveChanges();
            var patients = new Patient[]
            {
                new Patient{Name="Carson",Email="asd@mail.com",Password=123,Age=11,CNIC="3501-33",Disease="none"},
                new Patient{Name="Carson1",Email="new@mail.com",Password=123,CNIC="3501-33"},
                new Patient{Name="villa",Email="bi@mail.com",Password=1234325,CNIC="3501-33",Age=12,},
                   new Patient{Name="nilla",Email="hi@mail.com",Password=12453,CNIC="3501-33",Age=12,},
                    new Patient{Name="illa",Email="mill@mail.com",Password=541312,CNIC="3501-33",Age=12,},
                new Patient{Name="giila",Email="gill@mail.com",Password=2353,CNIC="3501-33",Age=12,},
                new Patient{Name="darson",Email="Abew@mail.com",Password=32423,CNIC="3501-33",Age=12,},
                new Patient{Name="sarson",Email="sarr@mail.com",Password=23423,CNIC="3501-33",Age=12,}
            };
            foreach (Patient p in patients)
            {
                context.Patients.Add(p);
            }
            context.SaveChanges();
            var Mrecords = new MedicalRecord[]
            {
                new MedicalRecord{PatientId=1,ShortDescription="jasgdahsda",images="sdjkasdgasj"},
                new MedicalRecord{PatientId=2,ShortDescription="jasgdahsda",images="sdjkasdgasj"},
                new MedicalRecord{PatientId=3,ShortDescription="jasgdahasdnsahdsasda",images="sdjkasdgasj"},
                new MedicalRecord{PatientId=4,ShortDescription="jasgdahsjhsadsjadda",images="sdjkasdgasj"},
                new MedicalRecord{PatientId=5,ShortDescription="jasgdaasdgagshsda",images="sdjkawerewsdgasj"},
                new MedicalRecord{PatientId=2,ShortDescription="jasgdaashdasghsda",images="sdjkasdgasj"},
                new MedicalRecord{PatientId=1,ShortDescription="jasgdasdyasahsda",images="sdjkasdgasj"},
                new MedicalRecord{PatientId=3,ShortDescription="jasgdhsadghahsda",images="sdjkaskdsajhduysadasdgasj"},
                new MedicalRecord{PatientId=1,ShortDescription="asdashfdsytaujasgdahsda",images="sasdhasgdjkasdgasj"},
            };
            foreach(MedicalRecord m in Mrecords)
            {
                context.MedicalRecords.Add(m);
            }
            context.SaveChanges();
            var dishist = new DiseaseHistory[]
            {
                new DiseaseHistory{DiseaseName="new1",Type="dfqeqweqw",duration="werqwe",patientId=1},
                new DiseaseHistory{DiseaseName="a1",Type="eqwkjlqk",duration="ywqrqw",patientId=1},
                new DiseaseHistory{DiseaseName="d2",Type="krqwiu",duration="yqwrwer",patientId=1},
                new DiseaseHistory{DiseaseName="sadas",Type="retwterfwe",duration="rwqerwe",patientId=4},
                new DiseaseHistory{DiseaseName="hgtrewe",Type="rqyrew",duration="rweqrwe",patientId=3},
                new DiseaseHistory{DiseaseName="yewter",Type="hweerq",duration="rwerasda",patientId=4},
                new DiseaseHistory{DiseaseName="weytre",Type="werwe",duration="asdswherw",patientId=3},
                new DiseaseHistory{DiseaseName="eyter",Type="werwerwerw",duration="wqrwed",patientId=2},
                new DiseaseHistory{DiseaseName="tuyrewf",Type="erwtert",duration="qdfq3t23",patientId=2},
            };
            foreach(DiseaseHistory d in dishist)
            {
                context.DiseaseHistories.Add(d);
            }
            context.SaveChanges();
            //var ad = new Admin[]
            //{
            //    new Admin{Name="shakeel",Password="shakeel",Email="shakeelzain89@gmail.com"},
            //    new Admin{Name="shakeel Ur Rehman",Password="shakeel12",Email="shakeelzain89@gmail.com"},
            //    new Admin{Name="admin",Password="admin",Email="admin@admin.com"},
            //    new Admin{Name="User",Password="user",Email="user@gamil.com"},
            //    new Admin{Name="Irfanullah",Password="irfan",Email="irfan@gmail.com"},
            //};
            //foreach(Admin adm in ad)
            //{
            //    context.Admins.Add(adm);
            //}
            //context.SaveChanges();
        }
    }
}
