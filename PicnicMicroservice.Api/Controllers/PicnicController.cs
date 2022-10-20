using Microsoft.AspNetCore.Mvc;
using PicnicMicroservice.Api.ViewModels;
using PicnicMicroservice.Application.Picnic.Commands;
using PicnicMicroservice.Application.Picnic.Queries;
using PicnicMicroservice.Application.PicnicInvite.Commands;
using PicnicMicroservice.Domain.Entities;

namespace PicnicMicroservice.Api.Controllers
{
    [Route("api/picnic")]
    [ApiController]
    public class PicnicController : BaseController
    {
        private readonly ILogger<PicnicController> _logger;

        public PicnicController(ILogger<PicnicController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public async Task<List<Picnic>> ListPicnics(CancellationToken cancellationToken)
        {
            try
            {
                var picnics = await Mediator.Send(new ListPicnicsQuery(), cancellationToken);
                return picnics;
            }
            catch (Exception ex)
            {
                _logger.LogError("An exception occured while listing Brands. Exception: {exception}", ex.Message);
                throw;
            }
        }

        [HttpGet]
        [Route("{picnicId}")]
        public async Task<Picnic> GetPicnic(string picnicId, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(picnicId, out Guid parsedId))
            {
                throw new BadHttpRequestException("Please send a valid Guid for picnicId");
            }

            try
            {
                var picnics = await Mediator.Send(new GetPicnicQuery() { PicnicId = Guid.Parse(picnicId) }, cancellationToken);
                return picnics;
            }
            catch (Exception ex)
            {
                _logger.LogError("An exception occured while listing Brands. Exception: {exception}", ex.Message);
                throw;
            }
        }

        [HttpPost]
        public async Task<ActionResult> PostPicnic(PostPicnicViewModel picnic, CancellationToken cancellationToken)
        {
            if (picnic == null || !Guid.TryParse(picnic.MemberId, out Guid parsedId))
            {
                throw new BadHttpRequestException("Please send a valid picnic object!");
            }

            try
            {
                var createdPicnic = await Mediator.Send(new CreatePicnicCommand() { Picnic = picnic.ToEntity() }, cancellationToken);
                return Created(Url.Action("GetPicnic", new { picnicId = createdPicnic }), createdPicnic);
            }
            catch (Exception ex)
            {
                _logger.LogError("An exception occured while listing Brands. Exception: {exception}", ex.Message);
                throw;
            }
        }

        [HttpPost]
        [Route("{picnicId}/invites")]
        public async Task<ActionResult> PostPicnicInvite(PostPicnicInviteViewModel invite, string picnicId, CancellationToken cancellationToken)
        {
            //We can use validator structure in this but for quick action I didn't add FluentValidations in the app.
            if (invite == null ||
                !Guid.TryParse(picnicId, out Guid parsedPicnicId) ||
                !Guid.TryParse(invite.MemberId, out Guid parsedMemberId))
            {
                throw new BadHttpRequestException("Please send a valid picnic invite object!");
            }

            try
            {
                try
                {
                    var createdInvite = await Mediator.Send(new CreatePicnicInviteCommand() { Invite = invite.ToEntity(picnicId) }, cancellationToken);

                    return Created(Url.Action("ListInvites", new { picnicId = picnicId }), picnicId);
                }
                catch (KeyNotFoundException nfEx)
                {
                    return NotFound();
                }


            }
            catch (Exception ex)
            {
                _logger.LogError("An exception occured while listing Brands. Exception: {exception}", ex.Message);
                throw;
            }
        }

        [HttpGet]
        [Route("{picnicId}/invites")]
        public async Task<List<PicnicInvite>> ListInvites(string picnicId, CancellationToken cancellationToken)
        {
            if (!Guid.TryParse(picnicId, out Guid parsedId))
            {
                throw new BadHttpRequestException("Please send a valid Guid for picnicId");
            }

            try
            {
                var picnicInvites = await Mediator.Send(new ListPicnicInvitesQuery() { PicnicId = Guid.Parse(picnicId) }, cancellationToken);
                return picnicInvites;
            }
            catch (Exception ex)
            {
                _logger.LogError("An exception occured while listing Brands. Exception: {exception}", ex.Message);
                throw;
            }
        }
    }
}
