using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge2
{


    public class ClaimRepository
    {
        private Queue<Claim> claimQueue;
        public ClaimRepository()
        {
            claimQueue = new Queue<Claim>();
        }
        public void AddClaimToQueue(Claim newClaim)
        {
            claimQueue.Enqueue(newClaim);
        }
        public Claim ClaimDequeue()
        {
            return claimQueue.Dequeue();
        }
        public Queue<Claim> GetClaims()
        {
            return claimQueue;
        }
        public Claim ClaimPeek(Queue<Claim> claims)
        {
            return claimQueue.Peek();
        }
    }
}