using Forpost.Business.Abstract.Services;
using Forpost.Store.Entities;
using Forpost.Web.Contracts.OrderBlock;
using Microsoft.AspNetCore.Mvc;


namespace Forpost.Web.Contracts.SettingsBlock
{
    /// <summary>
    /// Операции над настроенными блоками
    /// </summary>
    [Route("api/v1/settings-blocks/")]
    [ApiController]
    public sealed class SettingsBlockController: ControllerBase
    {
        private readonly ISettingsBlocksService _settingsBlocksService;

        public SettingsBlockController(ISettingsBlocksService settingsBlocksService)
        {
            _settingsBlocksService = settingsBlocksService;
        }
        ///<summary>
        ///Получаем все настроенные блоки из settings-blocks
        /// </summary>
        [HttpGet("get-all-settings-blocks")]
        public async Task<ActionResult<List<SettingsBlockResponse>>> GetAllSettingsBlocks(CancellationToken cancellationToken)
        {

            var settingsBlock = await _settingsBlocksService.GetAllSettingsBlocks(cancellationToken);

            var settingsBlockResponse = settingsBlock.Select(o => new SettingsBlockResponse
            {
                SerialNumber = o.SerialNumber,
                Block = o.Block,
                SettingOption = o.SettingOption,
                Note = o.Note,
                NumberInOrder = o.NumberInOrder?.ToString(),
                NumberRm = o.NumberRm,
                NumberNs = o.NumberNs,
                DateSetting = o.DateSetting,
                IdOrderBlocksInSetup = o.IdOrderBlocksInSetup

            }).ToList();

            return Ok(settingsBlockResponse);
        }
        /// <summary>
        /// Получаем блок по его серийному номеру
        /// </summary>
        /// <param name="serialNumber"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("get-settings-block-by-seria-number")]
        public async Task<ActionResult<List<SettingsBlockResponse>>> GetSettingsBlockBySerialNumber(int serialNumber, CancellationToken cancellationToken)
        {

            var settingsBlock = await _settingsBlocksService.GetSettingsBlockBySerialNumber(serialNumber, cancellationToken);

            var settingsBlockResponse = settingsBlock.Select(o => new SettingsBlockResponse
            {
                SerialNumber = o.SerialNumber,
                Block = o.Block,
                SettingOption = o.SettingOption,
                Note = o.Note,
                NumberInOrder = o.NumberInOrder?.ToString(),
                NumberRm = o.NumberRm,
                NumberNs = o.NumberNs,
                DateSetting = o.DateSetting,
                IdOrderBlocksInSetup = o.IdOrderBlocksInSetup

            }).ToList();
            if (settingsBlockResponse == null)
            {
                return NotFound();
            }
            return Ok(settingsBlockResponse);
        }
        /// <summary>
        /// Получаем список подходящих под счет блоков
        /// </summary>
        /// <param name="account"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        [HttpGet("get-settings-block-by-account")]
        public async Task<ActionResult<List<SettingsBlockResponse>>> GetSettingsBlockByAccount(string account, CancellationToken cancellationToken)
        {
            var settingsBlock = await _settingsBlocksService.GetSettingsBlockByAccount(account, cancellationToken);
            var settingsBlockResponse = settingsBlock.Select(o => new SettingsBlockResponse
            {
                SerialNumber = o.SerialNumber,
                Block = o.Block,
                SettingOption = o.SettingOption,
                Note = o.Note,
                NumberInOrder = o.NumberInOrder?.ToString(),
                NumberRm = o.NumberRm,
                NumberNs = o.NumberNs,
                DateSetting = o.DateSetting,
                IdOrderBlocksInSetup = o.IdOrderBlocksInSetup

            }).ToList();
            if (settingsBlockResponse == null)
            {
                return NotFound();
            }
            return Ok(settingsBlockResponse);
        }
        ///<summary>
        ///Апдейтим колонку id_order_progon у блока в settings_blocks
        /// </summary>
        [HttpPut("update-id-progon-of-settings-block")]
        public async Task<ActionResult> UpdateIdProgonOfSettingsBlock(int serialNumber, string account, CancellationToken cancellationToken)
        {
            await _settingsBlocksService.UpdateIdProgonOfSettingsBlock(serialNumber, account, cancellationToken);
            return Ok();
        }
    }
}
