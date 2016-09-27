using System;
using System.Collections.Generic;
using System.Linq;
using VOMO.Api.Models.Resources;
using VOMO.Context.Entities;
using VOMO.Web.Models;

namespace VOMO.Common
{
    public class PostToPostViewModelConverter : IMappingTypeConverter<Post, PostResource>
    {
        public PostResource Convert(Post source, MappingConfig mappingConfig)
        {
            return Convert(source, new PostResource(), mappingConfig);
        }

        public PostResource Convert(Post source, PostResource dest, MappingConfig mappingConfig)
        {
            var result = dest ?? new PostResource
            {
                Id = source.Id,
                Author = Mapper.Map<User, AuthorResource>(source.User),
                Content = source.Content,
                Title = source.Title,
                CreatedAt = source.CreatedAt,
                UpdatedAt = source.UpdatedAt,
                Tags = Mapper.Map<List<Tag>, List<TagResource>>(source.Tags.ToList())
            };

            return result;
        }
    }
}
