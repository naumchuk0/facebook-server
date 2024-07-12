﻿using ErrorOr;
using Facebook.Application.Common.Interfaces.IUnitOfWork;
using Facebook.Domain.Post;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Application.Post.Query.GetReactionByPostId;

public class GetReactionsByPostIdQueryHandler(IUnitOfWork unitOfWork) : IRequestHandler<GetReactionsByPostIdQuery, ErrorOr<IEnumerable<ReactionEntity>>>
{
    public async Task<ErrorOr<IEnumerable<ReactionEntity>>> Handle(GetReactionsByPostIdQuery request, CancellationToken cancellationToken)
    {
        try
        {
            var result = await unitOfWork.Reaction.GetReactionsByPostIdAsync(request.PostId);
            if (result.IsError)
            {
                return Error.Failure(result.Errors.ToString() ?? string.Empty);
            }
            return result;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error while receiving reactions: {ex.Message}");
            return Error.Failure($"Error while receiving reactions: {ex.Message}");
        }
    }
}
