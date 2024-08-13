using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using AuthApi.Entities;

namespace AuthApi.Models
{
    public class ProceedingResponse( string peopleId, string name)
    {

        public string PeopleId {get;set;} = peopleId;
        
        public string Name {get;set;} = name;
        
        public string? Folio {get;set;}

        public string? Status {get;set;}
        public int StatusId {get;set;}

        public string? Area {get;set;}
        public int AreaId {get;set;}

        public DateTime? CreatedAt {get;set;}
        


        public static ProceedingResponse FromIdentity(Proceeding p){
            var item = new ProceedingResponse(p.PersonId.ToString(), p.Name ?? "")
            {
                Folio = p.Folio,
                CreatedAt = p.CreatedAt
            };
            
            if ( p.Status != null){
                item.Status = p.Status.Name;
                item.StatusId = p.Status.Id;
            }
            
            if(p.Area != null){
                item.Area = p.Area.Name;
                item.AreaId = p.Area.Id;
            }
            
            return item;
        }

    }
}