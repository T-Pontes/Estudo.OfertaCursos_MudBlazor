using Core.Abstractions.Repositories;
using Api.Data.Context;
using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Api.Data.Repositories;
public class CourseRepository(AppDbContext context) : ICourseRepository
{
    public async Task<Course> CreateAsync(Course entity)
    {
        try
        {
            // Adicionar o objeto ao contexto e atualizar banco de dados 
            await context.Courses.AddAsync(entity);
            await context.SaveChangesAsync();

            // Retornar objeto salvo no banco de dados
            return entity;
        }
        catch (Exception ex)
        {
            throw new Exception($"Não foi possível salvar o(a) {GetType().Name} no banco da dados.{Environment.NewLine}" +
                                $"Mensagem: {ex.Message}");
        }
    }

    public async Task DeleteAsync(int id)
    {
        try
        {
            // Se o objeto não for encontrado no banco da dados com base no Id, lança a exceção
            var entity = await context.Courses.FirstOrDefaultAsync(x => x.Id == id);
            if (entity is null)
                throw new Exception($"O registro não foi encontrado no banco da dados");

            // Remove objeto passado por parâmetro
            context.Courses.Remove(entity);
            await context.SaveChangesAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Não foi possível remover o(a) {GetType().Name} no banco da dados.{Environment.NewLine}" +
                                $"Mensagem: {ex.Message}");
        }
    }

    public async Task<ICollection<Course>> GetAllAsync()
    {
        try
        {
            // Retorna a lista de objetos do banco de dados
            return await context.Courses.ToListAsync();
        }
        catch (Exception ex)
        {
            throw new Exception($"Não foi possível listar os objetos {GetType().Name} do banco da dados.{Environment.NewLine}" +
                                $"Mensagem: {ex.Message}");
        }
    }

    public async Task<Course?> GetByIdAsync(int id)
    {
        try
        {
            // Retona o objeto com base no valor do Id
            return await context.Courses.FirstOrDefaultAsync(x =>  x.Id == id);
        }
        catch (Exception ex)
        {
            throw new Exception($"Não foi possível encontrar o objeto {GetType().Name} informado no banco da dados.{Environment.NewLine}" +
                                $"Mensagem: {ex.Message}");
        }
    }

    public async Task<Course> UpdateAsync(Course entity)
    {
        try
        {
            // Se o objeto não for encontrado no banco da dados com base no Id, lança a exceção
            if (await context.Courses.FirstOrDefaultAsync(x => x.Id == entity.Id) is null)
                throw new Exception($"O registro não foi encontrado no banco da dados");

            // Caso exista na banco de dados, executa a atualização do objeto
            context.Courses.Update(entity);
            await context.SaveChangesAsync();

            // Retornar objeto atualizado no banco de dados
            return entity;
        }
        catch (Exception ex)
        {
            throw new Exception($"Não foi possível atualizar o(a) {GetType().Name} no banco da dados.{Environment.NewLine}" +
                                            $"Mensagem: {ex.Message}");
        }
    }
}
