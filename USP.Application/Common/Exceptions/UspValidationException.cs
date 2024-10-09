namespace USP.Application.Common.Exceptions;

public class UspValidationException(IDictionary<string, string[]> failures) : BaseException("One or more validation failures have occurred.", failures);