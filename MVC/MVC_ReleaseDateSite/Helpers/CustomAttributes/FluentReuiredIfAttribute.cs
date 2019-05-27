using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using MVC_ReleaseDateSite.ViewModels;

namespace MVC_ReleaseDateSite.Helpers.CustomAttributes {
    public class FluentReuiredIfAttribute : AbstractValidator<CreateReleaseViewModel> {
        public FluentReuiredIfAttribute() {
            RuleFor(x => x.ImgFile).NotEmpty().When(x => string.IsNullOrEmpty(x.ImgLocation)).WithMessage("Either an image file or an image url is required");
        }
    }
}
