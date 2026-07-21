using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MediatR;
using TaskFlow.Domain.Entities;
using TaskFlow.Application.Interfaces;


namespace TaskFlow.Application.Features.Categories.Commands.UpdateCategory
{
    public class UpdateCategoryHandler : IRequestHandler<UpdateCategoryCommand, bool>
    {
        private readonly ICategoryRepository _categoryRepository;
        public UpdateCategoryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<bool> Handle( UpdateCategoryCommand request , CancellationToken cancellationToken)
        {
            var category = await _categoryRepository.GetByIdAsync(request.Id);

            if (category is null)
                throw new Exception("Category Not Found");

            category.Name = request.Name;

            await _categoryRepository.UpdateAsync(category);

            return true;
        }


    }
}
