﻿using ErrorOr;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Facebook.Application.Comment.Command.Add;

public record AddCommentCommand(
    string Message,
    Guid UserId,
    Guid PostId
) : IRequest<ErrorOr<Unit>>;
