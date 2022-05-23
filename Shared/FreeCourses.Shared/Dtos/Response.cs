using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace FreeCourses.Shared.Dtos
{
    public class Response<T>
    {
        public T Data { get;private set; } //Başarılı olduğunda doldurulacak
        [JsonIgnore]//Response nesnesinde olmasına gerek yok ama biz bu property i kullanacağız.
        public int StatusCode { get;private set; }
        [JsonIgnore]
        public bool IsSuccessful { get;private set; }
        public List<string> Errors { get; set; } //Başarısız olduğunda doldurulacak

        //Static Factory Method 
        public static Response<T> Success(T data,int statusCode)
        {
            return new Response<T> { Data = data, StatusCode = statusCode , IsSuccessful= true};
        }

        public static Response<T> Success(int statusCode)
        {
            return new Response<T> { Data = default(T), StatusCode = statusCode , IsSuccessful= true};
        }
        public static Response<T> Fail(List<string> errors,int statusCode)
        {
            return new Response<T> { Errors = errors, StatusCode = statusCode , IsSuccessful= false};
        }

        public static Response<T> Fail(string error,int statusCode)
        {
            return new Response<T> { Errors = new List<string> { error }, StatusCode = statusCode , IsSuccessful= false};
        }
    }
}
