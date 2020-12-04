using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// I will get terminology wrong btw

namespace RedWolfDataCrunch
{
    public enum Gender
    {
        Male,
        Female
    }

    public enum Class
    {
        UpperClass,
        NormalClass
    }

    public class RedWolf
    {
        // Wolf Properties
        public Gender Gender;
        public Class Class;

        public int ID;
        public int Age;
        public float Kinship;

        // Alleles
        public string EarSize;
        public string PawSize;
        public string LegLength;

        // Wolf Relashions
        public RedWolf Father = null;
        public RedWolf Mother = null;
        public List<RedWolf> Siblings = new List<RedWolf>();
        public List<RedWolf> Children = new List<RedWolf>();

        /// <summary>
        /// Checks if a proper allele
        /// </summary>
        /// <param name="allele">the allele to check</param>
        /// <param name="set">what to set</param>
        /// <returns></returns>
        private bool AlleleSetCheck(string allele, string @set)
        {
            if (allele.Length != 2)
                return false;

            string gen = string.Empty;

            gen += char.ToLower(allele[0]);
            gen += char.ToLower(allele[0]);

            if (allele.ToLower() != gen)
                return false;

            switch (set)
            {
                case "EarSize":
                    EarSize = allele;
                    break;
                case "LegLength":
                    LegLength = allele;
                    break;
                case "PawSize":
                    PawSize = allele;
                    break;
                case "check":
                    break;
                default:
                    Output.PrintOperation($"RedWolf._Internal{{{ID}}}.AlleleSetCheck - Failed due to the fact no allele was specified");
                    Environment.Exit(-1);
                    break;
            }

            return true;
        }

        // This is mostly for punnett square creation
        public class ReproductiveFunctions
        {
            // Yes ik this is a unneeded copy of a function but I'm too lazy also for most modern day processors they wouldn't care
            private static bool AlleleCheck(string allele)
            {
                if (allele.Length != 2)
                    return false;

                string gen = string.Empty;

                gen += char.ToLower(allele[0]);
                gen += char.ToLower(allele[0]);

                if (allele.ToLower() != gen)
                    return false;

                return true;
            }

            private static bool IsDominante(char part)
            {
                return char.IsUpper(part);
            }

            private static string BuildAllele(char pair1, char pair2)
            {
                StringBuilder builder = new StringBuilder();
                builder.Append(pair1);
                builder.Append(pair2);
                return builder.ToString();
            }

            private static string GenerateViaDominance(char pair1, char pair2)
            {
                if (IsDominante(pair1))
                    return BuildAllele(pair1, pair2);
                else if (IsDominante(pair2))
                    return BuildAllele(pair2, pair1);
                else
                    return BuildAllele(pair2, pair1);
            }

            /// <summary>
            /// Creates a List/Punnett Square
            /// </summary>
            /// <param name="allele1">The first allele used</param>
            /// <param name="allele2">Second Allele used</param>
            /// <returns></returns>
            public static List<string> EvaluateAlleles(string allele1, string allele2)
            {
                // Add Punnett Square looks something like
                /*
                      E        e
                   *----------------*
                 E |  EE       Ee   |
                   |                |
                 E |  EE       Ee   |
                   *----------------*
                 
                   It's basically a way to guess the probability of offspring traits
                */
                if (!AlleleCheck(allele1))
                {
                    Output.PrintError("Allele1 for reproduction is not valid");
                    Environment.Exit(-1);
                }

                if (!AlleleCheck(allele2))
                {
                    Output.PrintError("Allele2 for reproduction is not valid");
                    Environment.Exit(-1);
                }

                char[] allele1_split = { allele1[0], allele1[1] };
                char[] allele2_split = { allele2[0], allele2[1] };
                
                List<string> square = new List<string>();
                // Doing top of the square The:         E       e      | Part of the Example at the top
                square.Add(GenerateViaDominance(allele1_split[0], allele2_split[0]));
                square.Add(GenerateViaDominance(allele1_split[1], allele2_split[0]));
                // Doing the other:     E       E       | Part of the Example
                square.Add(GenerateViaDominance(allele1_split[0], allele2_split[1]));
                square.Add(GenerateViaDominance(allele1_split[1], allele2_split[1]));

                return square;
            }
        }

        /// <summary>
        /// This is just a simple function that will take in a different wolf and it will generate a child wolf out of it. The mother will be the parent of the newly formed cub
        /// </summary>
        /// <param name="Partner">This is the other wolf I was talking about</param>
        /// <returns>It returns the breed between the two a hybrid of the two. It will return null if the partner is the same gender or is a parent of the wolf or is one of it's siblings</returns>
        public RedWolf Breed(RedWolf Partner)
        {
            Output.PrintOperation($"Breeding Red Wolf {ID} with Red Wolf {Partner.ID}");

            if (Siblings.Contains(Partner))
            {
                Output.PrintError("Partner is a Sibling");
                Environment.Exit(-1);
            }

            if (Gender == Partner.Gender)
            {
                Output.PrintError("Can't Breed Wolfs the same gender");
                Environment.Exit(-1);
            }

            if (Partner.Kinship > 0.115f || Kinship > 0.115f)
            {
                Output.PrintError("Too high of a Kinship");
                Environment.Exit(-1);
            }

            if (Partner == Mother || Partner == Father)
            {
                Output.PrintError("The Partner is a Parent");
                Environment.Exit(-1);
            }

            if (Partner.Age > 11 && Partner.Gender == Gender.Female || Age > 11 && Gender == Gender.Female)
            {
                Output.PrintError("Female is too old");
                Environment.Exit(-1);
            }

            Random random = new Random(); // This will be the thing that will generate "randomness"

            // Generate Alleles for each trait
            List<string> cEarSize   = ReproductiveFunctions.EvaluateAlleles(EarSize,   Partner.EarSize);
            List<string> cPawSize   = ReproductiveFunctions.EvaluateAlleles(PawSize,   Partner.PawSize);
            List<string> cLegLength = ReproductiveFunctions.EvaluateAlleles(LegLength, Partner.LegLength);

            float cKinship = (Kinship + Partner.Kinship) / 2;

            int cID = Int32.Parse(ID.ToString() + Partner.ID.ToString() + random.Next(0, 50000).ToString());
            bool flag = false;

            // this is a crappy way of making sure wolfs don't have the same id but eh
            while (true)
            {
                foreach (RedWolf wolf in Data.Wolfs)
                    if (wolf.ID == cID)
                    {
                        flag = true;
                    }

                if (flag) {
                    cID = Int32.Parse(ID.ToString() + Partner.ID.ToString() + random.Next(0, 50000).ToString());
                    flag = false;
                    continue;
                }
                else
                    break;
            }

            RedWolf child = new RedWolf(random.Next(1, 3) == 1 ? Gender.Male : Gender.Female, Partner.Class == Class.UpperClass ? Class.UpperClass : Class == Class.UpperClass ? Class.UpperClass : Class.NormalClass, cID, 0, cKinship, cEarSize[random.Next(0, 4)], cPawSize[random.Next(0, 4)], cLegLength[random.Next(0, 4)], Partner.Gender == Gender.Female ? Partner : this, Partner.Gender == Gender.Male ? Partner : this);

            AddChild(child);
            Partner.AddChild(child);

            return child;
        }

        /// <summary>
        /// Pairs the two wolfs as siblings
        /// </summary>
        /// <param name="Sibling"></param>
        public void AddSibling(RedWolf Sibling)
        {
            if (!Siblings.Contains(Sibling))
                Siblings.Add(Sibling);
            if (!Sibling.Siblings.Contains(this))
                Sibling.AddSibling(this);
        }

        public void AddChild(RedWolf Child)
        {
            if (!Children.Contains(Child))
                Children.Add(Child);
            foreach (RedWolf child in Children)
                child.AddSibling(Child);
        }

        public RedWolf(Gender gender, Class @class, int id, int age, float kinship, string earSize, string pawSize, string legLength, RedWolf mother=null, RedWolf father=null)
        {
            Output.PrintOperation($"Constructing RedWolf {id}...");
            Mother = mother;
            Father = father;
            Gender = gender;
            ID = id;
            Age = age;
            Kinship = kinship;
            Class = @class;
            
            if (!AlleleSetCheck(earSize, "EarSize"))
            {
                Output.PrintError($"RedWolf{{{id}}}.Constructor - Failed to set EarSize allele");
                Console.ReadKey();
                Environment.Exit(-1);
            }

            if (!AlleleSetCheck(legLength, "LegLength"))
            {
                Output.PrintError($"RedWolf{{{id}}}.Constructor - Failed to set LegLength allele");
                Console.ReadKey();
                Environment.Exit(-1);
            }

            if (!AlleleSetCheck(pawSize, "PawSize"))
            {
                Output.PrintError($"RedWolf{{{id}}}.Constructor - Failed to set PawSize allele");
                Console.ReadKey();
                Environment.Exit(-1);
            }
            Output.PrintOperation($"Finished Constructing...");
            Data.Wolfs.Add(this);
        }
    }
}
