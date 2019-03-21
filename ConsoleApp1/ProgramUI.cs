using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2
{
   public class ProgramUI
    {
        private ClaimRepository _claimRepo = new ClaimRepository();
       
        public void Run()
        {
            _claimRepo.AddClaimToQueue(new Claim("1",ClaimType.car,"Car accident on 465.",400m,DateTime.Parse("4/25/18"), DateTime.Parse("4/27/18"), true));
            _claimRepo.AddClaimToQueue(new Claim("2", ClaimType.home, "House fire in kitchen.", 4000m, DateTime.Parse("4/26/18"), DateTime.Parse("4/28/18"), true));
            _claimRepo.AddClaimToQueue(new Claim("3", ClaimType.theft, "Stolen pancakes.      ", 4m, DateTime.Parse("4/27/18"), DateTime.Parse("6/01/18"), false));
            bool running = true;
            while (running)
            {
                Console.Clear();
                Console.WriteLine("Komodo Claims Department");
                Console.WriteLine("------------------------");
                Console.WriteLine("\n" +
                    "Main Menu: \n" +
                    "--------- \n" +
                    "1. See all claims \n" +
                    "2. Take care of next claim \n" +
                    "3. Enter a new claim \n" +
                    "4. Exit");
                int input = int.Parse(Console.ReadLine());
                switch (input)
                {
                    case 1:
                        SeeAllClaims();
                        break;
                    case 2:
                        TakeCareOfNextClaim();
                        break;
                    case 3:
                        EnterANewClaim();
                        break;
                    case 4:
                        running = false;
                        break;
                }
            }

        }
        private void SeeAllClaims()
        {
            Console.Clear();
            Queue<Claim> claims = _claimRepo.GetClaims();
            Console.WriteLine("ClaimID TypeOfClaim    ClaimDescription     ClaimAmount       DateOfIncident         DateOfClaim            IsValid");
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            foreach (Claim claim in claims)
            {
                Console.WriteLine($"{claim.ClaimID,-5} {claim.ClaimType,-12} {claim.Description,-12}        {claim.ClaimAmount,-12} {claim.DateOfIncident,-12} {claim.DateOfClaim,-12}     {claim.IsValid,-12}", _claimRepo.GetClaims());
            }
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(" \n" +
                "\n" +
                "Press any key to continue: ");
            Console.ReadKey();
        }
        private void TakeCareOfNextClaim()
        {
            Claim claim = _claimRepo.GetClaims().Peek();
            Console.WriteLine("Claim: ID: {0}", claim.ClaimID);
            Console.WriteLine("Type: {0}", claim.Description);
            Console.WriteLine("Description: {0}", claim.Description);
            Console.WriteLine("Amount: {0}", claim.ClaimAmount);
            Console.WriteLine("Date of Incident: {0}", claim.DateOfIncident);
            Console.WriteLine("Date of Claim: {0}", claim.DateOfClaim);
            Console.WriteLine("Valid claim: {0}", claim.IsValid);
            Console.WriteLine("Do you want to deal with this claim now? (y or n)");
            string takeNextClaim = Console.ReadLine();
            if (takeNextClaim.ToLower() == "y")
            {
                _claimRepo.ClaimDequeue();
            }
        }
        private void EnterANewClaim()
        {
            Console.Clear();
            Claim newClaim = new Claim();
            Console.WriteLine("Please enter your claim number: ");
            newClaim.ClaimID = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Please enter the claim type: \n" +
                "1. car \n" +
                "2. home \n" +
                "3. theft");
            string claimTypeInput = Console.ReadLine().ToLower();
            switch (claimTypeInput)
            {
                case "1":
                case "car":
                    newClaim.ClaimType = ClaimType.car;
                    break;
                case "2":
                case "home":
                    newClaim.ClaimType = ClaimType.home;
                    break;
                case "3":
                case "theft":
                    newClaim.ClaimType = ClaimType.theft;
                    break;
            }
            Console.Clear();
            Console.WriteLine("Please enter a brief claim description: ");
            newClaim.Description = Console.ReadLine();
            Console.Clear();
            Console.WriteLine("Please enter the claim ammount");
            newClaim.ClaimAmount = int.Parse(Console.ReadLine());
            Console.Clear();
            Console.WriteLine("Please enter the date of the incident: (example: 01/02/18)");
            newClaim.DateOfIncident = DateTime.Parse(Console.ReadLine());
            newClaim.DateOfClaim = DateTime.Now;
            Console.Clear();
            Console.WriteLine("Is this a valid claim? (yes/no)");
            string validClaim = Console.ReadLine().ToLower();
            if (validClaim == "yes")
            {
                newClaim.IsValid = true;
            }
            else if (validClaim == "no")
            {
                newClaim.IsValid = false;
            }
            else
            {
                Console.Clear();
                Console.WriteLine("Please enter yes or no");
            }

            _claimRepo.AddClaimToQueue(newClaim);
        }
    }
}
