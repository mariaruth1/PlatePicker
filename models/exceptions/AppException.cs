namespace models.exceptions;


public abstract class AppException(string error) : System.Exception(error);
