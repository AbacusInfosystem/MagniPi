using MagniPiBusinessEntities.Common;
using MagniPiBusinessEntities.Testimonial;
using MagniPiDataAccess.Testimonial;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MagniPiManager.Testimonial
{
    public class TestimonialManager
    {

        TestimonialRepo _testimonialRepo;

        public TestimonialManager()
        {
            _testimonialRepo = new TestimonialRepo();
        }

        public int Insert_Testimonial(TestimonialInfo testimonial)
        {
            return _testimonialRepo.Insert_Testimonial(testimonial);
        }

        public void Update_Testimonial(TestimonialInfo testimonial)
        {
            _testimonialRepo.Update_Testimonial(testimonial);
        }

        public List<TestimonialInfo> Get_Testimonials(ref PaginationInfo Pager)
        {
            return _testimonialRepo.Get_Testimonials(ref Pager);
        }

        public TestimonialInfo Get_Testimonial_By_Id(int Testimonial_Id)
        {
            return _testimonialRepo.Get_Testimonial_By_Id(Testimonial_Id);
        }
       

    }
}
