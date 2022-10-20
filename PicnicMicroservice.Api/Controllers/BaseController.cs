using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace PicnicMicroservice.Api.Controllers
{
    public abstract class BaseController : Controller
    {
        private ISender _mediator = null!;

        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
    }
}
