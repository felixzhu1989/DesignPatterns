using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrototypeBuilder
{
    public class ResumeBuilder:IResumeBuilder
    {
        private readonly BasicInfo _basicInfo = new BasicInfo();
        private readonly WorkExperience _workExperience = new WorkExperience();
        public IResumeBuilder BuildBasicInfo(Action<BasicInfo> buildBasicInfoDelegate)
        {
            buildBasicInfoDelegate?.Invoke(_basicInfo);
            return this;
        }

        public IResumeBuilder BuildWorkExperience(Action<WorkExperience> buildWorkExperienceDelegate)
        {
            buildWorkExperienceDelegate?.Invoke(_workExperience);
            return this;
        }

        public ResumeBase Build()
        {
            ItResume resume=new ItResume()
            {
                Name = this._basicInfo.Name,
                Gender = this._basicInfo.Gender,
                Age = this._basicInfo.Age,
                ExpectedSalary = this._basicInfo.ExpectedSalary,
                WorkExperience = new WorkExperience()
                {
                    Company = this._workExperience.Company,
                    Detail = this._workExperience.Detail,
                    StartDate = this._workExperience.StartDate,
                    EndDate = this._workExperience.EndDate
                }
            };
            return resume;
        }
    }
}
