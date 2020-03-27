﻿using System.Threading;
using System.Threading.Tasks;
using FOSCBot.Common.Helper;
using MediatR;
using Navigator;
using Navigator.Abstraction;
using Navigator.Actions;

namespace FOSCBot.Core.Domain.Command.Boi
{
    public class BoiCommandActionHandler : ActionHandler<BoiCommandAction>
    {
        public static readonly string[] Stickers = {
            "CAACAgQAAxkBAAI5Hl59wgU-EjcPoQJXOk81dz15rU6vAAIXAAMN0oYC8U1SU9k9QFQYBA",
            "CAACAgQAAxkBAAI5H159wgZdNShe0hTs65NLdinvP9v5AAIOAAMN0oYCfWiupsMYNyUYBA",
            "CAACAgQAAxkBAAI5Il59wgpjoo8hIuSmS7HRs44rneMRAAIeAAMN0oYCa2VzcOI0p0sYBA",
        };
        public BoiCommandActionHandler(INavigatorContext ctx) : base(ctx)
        {
        }

        public override async Task<Unit> Handle(BoiCommandAction request, CancellationToken cancellationToken)
        {
            var randomSticker = Stickers[RandomProvider.GetThreadRandom().Next(0, Stickers.Length)];

            await Ctx.Client.SendStickerAsync(Ctx.GetTelegramChat(), randomSticker, cancellationToken: cancellationToken);
            
            return Unit.Value;
        }
    }
}