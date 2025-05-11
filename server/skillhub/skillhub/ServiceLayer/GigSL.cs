﻿using skillhub.Interfaces.IRepositryLayer;
using skillhub.Interfaces.IServiceLayer;
using skillhub.CommonLayer.Model.Gigs;
using skillhub.RepositeryLayer;


namespace skillhub.ServiceLayer
{
    public class GigSL : IGigSL
    {
        public readonly IGigRL Gig;
        public GigSL(IGigRL gig)
        {
            this.Gig = gig;
        }
        public Task<bool> AddFreelancerGig(GigRequest gigRequest)
        {
            Gig gig = new Gig(gigRequest.userId, gigRequest.title, gigRequest.description, gigRequest.categoryId);
            return Gig.AddFreelancerGig(gig);
        }
        public Task<bool> DeleteGig(int id)
        {
            return Gig.DeleteGig(id);
        }

        public Task<Gig> GetGig(int id)
        {
            return Gig.GetGig(id);
        }

        public Task<bool> UpdateGig(int id, GigRequest gigRequest)
        {
            Gig gig = new Gig(gigRequest.userId, gigRequest.title, gigRequest.description, gigRequest.categoryId);
            return Gig.UpdateGig(id, gig);
        }

    }

}
