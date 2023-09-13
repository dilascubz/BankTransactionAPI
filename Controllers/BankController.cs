using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using EvaluationTest.Service;
using EvaluationTest.Models;


namespace EvaluationTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BankController : ControllerBase
    {
        private BankDetail _activityService;

        public BankController()
        {
            _activityService = new BankDetail();
        }

        [HttpGet]
        public IActionResult GetAllAdvertisements(string userid)
        {
            var activity = _activityService.GetActiveAccounts(userid);
            return Ok(activity);
        }


        [HttpPost]
        public int AddActivity(BankAccount activity)
        {
            if (_activityService.CheckExistsActivity(activity.AccId))
            {
                return -1;
            }
            activity.CreatedDateTime = DateTime.Now;
            return _activityService.CreateAccount(activity);
        }



        [HttpPut("{id}")]
        public ActionResult WithdrawMoney(int id, BankAccount act)
        {
            if (id != act.Id)
            {
                return BadRequest();
            }

            if (_activityService.CheckExistsUpdateActivity(act.UserId, id))
            {
                return Ok(-1);
            }


            if (_activityService.CheckAmount(act.UserId, act.BankAmount))
            {
                return Ok(-1);
            }

            var updateActivity = _activityService.GetActivity(id);
            if (updateActivity is null)
            {
                return NotFound();
            }

            updateActivity.BankAmount = act.BankAmount;
           
            updateActivity.LastModifiedBy = act.LastModifiedBy;
            updateActivity.LastModifiedDateTime = DateTime.Now;
            _activityService.UpdateActivity(updateActivity);
            return NoContent();

        }



        [HttpPut("{id}")]
        public ActionResult TransferMoney(int id, string ReceiverBankAccount, BankAccount act)
        {
            if (id != act.Id)
            {
                return BadRequest();
            }

            if (_activityService.CheckExistsUpdateActivity(act.UserId, id))
            {
                return Ok(-1);
            }


            if (_activityService.CheckAmount(act.UserId, act.BankAmount))
            {
                return Ok(-1);
            }

            var updateActivity = _activityService.GetActivity(id);
            if (updateActivity is null)
            {
                return NotFound();
            }

            updateActivity.BankAmount = act.BankAmount- Convert.ToDecimal(ReceiverBankAccount);

            updateActivity.LastModifiedBy = act.LastModifiedBy;
            updateActivity.LastModifiedDateTime = DateTime.Now;
            _activityService.UpdateActivity(updateActivity);
            return NoContent();

        }



    }
}
