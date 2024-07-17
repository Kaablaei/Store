﻿using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Categorys.GetCatrgory
{
    public record GetCategoryQuery(int Id) : IRequest<GetCategoryQueryResponse>;

}
