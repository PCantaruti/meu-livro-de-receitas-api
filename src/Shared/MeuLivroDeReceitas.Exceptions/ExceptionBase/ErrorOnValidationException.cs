namespace MeuLivroDeReceitas.Exceptions.ExceptionBase
{
    public class ErrorOnValidationException : MeuLivroDeReceitasException
    {
        public IList<string> ErrorMessages { get; set; }

        public ErrorOnValidationException(IList<string> errors)
        {
            ErrorMessages = errors;
        }
    }
}
