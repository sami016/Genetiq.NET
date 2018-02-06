using Genetiq.Representations.Sequences;
using Genetiq.Utility.DataSet;
using System;
using System.Collections.Generic;
using System.Text;

namespace Genetiq.Examples._2_linear_classification_task
{
    public static class TestDataSet
    {
        public static readonly LabelledDataSet<Sequence<double>, LocationClass> AllData;
        public static readonly LabelledDataSet<Sequence<double>, LocationClass> TrainingData;
        public static readonly LabelledDataSet<Sequence<double>, LocationClass> TestingData;

        static TestDataSet()
        {
            AllData = new LabelledDataSet<Sequence<double>, LocationClass>(new Random());

            // UK cities.
            // Elgin
            AllData.Add(LocationClass.UnitedKingdom, Sequence<double>.From(57.653484, -3.335724));
            // Stoke-on-Trent
            AllData.Add(LocationClass.UnitedKingdom, Sequence<double>.From(53.002666, -2.179404));
            // Solihull
            AllData.Add(LocationClass.UnitedKingdom, Sequence<double>.From(52.412811, -1.778197));
            // Cardiff
            AllData.Add(LocationClass.UnitedKingdom, Sequence<double>.From(51.481583, -3.179090));
            // Eastbourne
            AllData.Add(LocationClass.UnitedKingdom, Sequence<double>.From(50.768036,   0.290472));
            // Oxford
            AllData.Add(LocationClass.UnitedKingdom, Sequence<double>.From(51.752022, - 1.257677));
            // London
            AllData.Add(LocationClass.UnitedKingdom, Sequence<double>.From(51.509865, - 0.118092));
            // Swindon
            AllData.Add(LocationClass.UnitedKingdom, Sequence<double>.From(51.568535, - 1.772232));
            // Gravesend
            AllData.Add(LocationClass.UnitedKingdom, Sequence<double>.From(51.441883,   0.370759));
            // Northampton
            AllData.Add(LocationClass.UnitedKingdom, Sequence<double>.From(52.240479, - 0.902656));
            // Rugby
            AllData.Add(LocationClass.UnitedKingdom, Sequence<double>.From(52.370876, - 1.265032));
            // Sutton Coldfield
            AllData.Add(LocationClass.UnitedKingdom, Sequence<double>.From(52.570385, - 1.824042));
            // Harlow
            AllData.Add(LocationClass.UnitedKingdom, Sequence<double>.From(51.772938,   0.102310));
            // Aberdeen
            AllData.Add(LocationClass.UnitedKingdom, Sequence<double>.From(57.149651, - 2.099075));
            // Swansea
            AllData.Add(LocationClass.UnitedKingdom, Sequence<double>.From(51.621441, - 3.943646));
            // Chesterfield
            AllData.Add(LocationClass.UnitedKingdom, Sequence<double>.From(53.235046, - 1.421629));
            // Londonderry
            AllData.Add(LocationClass.UnitedKingdom, Sequence<double>.From(55.006763, - 7.318268));
            // Salisbury
            AllData.Add(LocationClass.UnitedKingdom, Sequence<double>.From(51.068787, - 1.794472));
            // Weymouth
            AllData.Add(LocationClass.UnitedKingdom, Sequence<double>.From(50.614429, - 2.457621));
            // Wolverhampton
            AllData.Add(LocationClass.UnitedKingdom, Sequence<double>.From(52.591370, - 2.110748));
            // Preston
            AllData.Add(LocationClass.UnitedKingdom, Sequence<double>.From(53.765762, - 2.692337));
            // Bournemouth
            AllData.Add(LocationClass.UnitedKingdom, Sequence<double>.From(50.720806, - 1.904755));
            // Doncaster
            AllData.Add(LocationClass.UnitedKingdom, Sequence<double>.From(53.522820, - 1.128462));
            // Ayr
            AllData.Add(LocationClass.UnitedKingdom, Sequence<double>.From(55.458565, - 4.629179));
            // Hastings
            AllData.Add(LocationClass.UnitedKingdom, Sequence<double>.From(50.854259,   0.573453));
            // Bedford
            AllData.Add(LocationClass.UnitedKingdom, Sequence<double>.From(52.136436, - 0.460739));
            // Basildon
            AllData.Add(LocationClass.UnitedKingdom, Sequence<double>.From(51.572376,   0.470009));
            // Chippenham
            AllData.Add(LocationClass.UnitedKingdom, Sequence<double>.From(51.458057, - 2.116074));
            // Belfast
            AllData.Add(LocationClass.UnitedKingdom, Sequence<double>.From(54.607868, - 5.926437));
            // Uckfield
            AllData.Add(LocationClass.UnitedKingdom, Sequence<double>.From(50.967941,   0.085831));
            // Worthing
            AllData.Add(LocationClass.UnitedKingdom, Sequence<double>.From(50.825024, - 0.383835));
            // Leeds
            AllData.Add(LocationClass.UnitedKingdom, Sequence<double>.From(53.801277, - 1.548567));
            // Kendal
            AllData.Add(LocationClass.UnitedKingdom, Sequence<double>.From(54.328506, - 2.743870));
            // Plymouth
            AllData.Add(LocationClass.UnitedKingdom, Sequence<double>.From(50.376289, - 4.143841));
            // Haverhill
            AllData.Add(LocationClass.UnitedKingdom, Sequence<double>.From(52.080875,   0.444517));
            // Frankton
            AllData.Add(LocationClass.UnitedKingdom, Sequence<double>.From(52.328415, - 1.377561));
            // Inverness
            AllData.Add(LocationClass.UnitedKingdom, Sequence<double>.From(57.477772, - 4.224721));

            // France cities.
            // Dunkirk.
            AllData.Add(LocationClass.France, Sequence<double>.From(51.050030, 2.397766));
            // Lille
            AllData.Add(LocationClass.France, Sequence<double>.From(50.629250, 3.057256));
            // Brest
            AllData.Add(LocationClass.France, Sequence<double>.From(52.097622, 23.734051));
            // Menton
            AllData.Add(LocationClass.France, Sequence<double>.From(43.774483, 7.497540));
            // Bastia
            AllData.Add(LocationClass.France, Sequence<double>.From(42.697285, 9.450881));
            // Cannes
            AllData.Add(LocationClass.France, Sequence<double>.From(43.552849, 7.017369));
            // Beuvais
            AllData.Add(LocationClass.France, Sequence<double>.From(49.431744, 2.089773));
            // Mulhouse
            AllData.Add(LocationClass.France, Sequence<double>.From(47.750839, 7.335888));
            // Bordeux
            AllData.Add(LocationClass.France, Sequence<double>.From(44.836151, -0.580816));
            // Boulogne-Billancourt 
            AllData.Add(LocationClass.France, Sequence<double>.From(48.843933, 2.247391));
            // Montauban
            AllData.Add(LocationClass.France, Sequence<double>.From(44.022125, 1.352960));
            // Amiens
            AllData.Add(LocationClass.France, Sequence<double>.From(49.894066, 2.295753));
            // Laval
            AllData.Add(LocationClass.France, Sequence<double>.From(48.101929, -0.766296));
            // Bourg-en-Bresse
            AllData.Add(LocationClass.France, Sequence<double>.From(46.202789, 5.219246));
            // Nancy
            AllData.Add(LocationClass.France, Sequence<double>.From(48.692055, 6.184417));
            // Nice
            AllData.Add(LocationClass.France, Sequence<double>.From(43.675819, 7.289429));
            // Paris
            AllData.Add(LocationClass.France, Sequence<double>.From(48.864716, 2.349014));
            // Calais 
            AllData.Add(LocationClass.France, Sequence<double>.From(50.954468, 1.862801));

            AllData.Split(0.5f, out TrainingData, out TestingData);

        }
    }

}
