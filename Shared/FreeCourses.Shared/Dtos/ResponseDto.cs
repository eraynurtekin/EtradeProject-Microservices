﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace FreeCourses.Shared.Dtos
{
    public class ResponseDto<T>
    {
        public T Data { get;private set; } //Başarılı olduğunda doldurulacak
        [JsonIgnore]//Response nesnesinde olmasına gerek yok ama biz bu property i kullanacağız.
        public int StatusCode { get;private set; }
        [JsonIgnore]
        public bool IsSuccessful { get;private set; }
        public List<string> Errors { get; set; } //Başarısız olduğunda doldurulacak

        //Static Factory Method 
        public static ResponseDto<T> Success(T data,int statusCode)
        {
            return new ResponseDto<T> { Data = data, StatusCode = statusCode , IsSuccessful= true};
        }

        public static ResponseDto<T> Success(int statusCode)
        {
            return new ResponseDto<T> { Data = default(T), StatusCode = statusCode , IsSuccessful= true};
        }
        public static ResponseDto<T> Fail(List<string> errors,int statusCode)
        {
            return new ResponseDto<T> { Errors = errors, StatusCode = statusCode , IsSuccessful= false};
        }

        public static ResponseDto<T> Fail(string error,int statusCode)
        {
            return new ResponseDto<T> { Errors = new List<string> { error }, StatusCode = statusCode , IsSuccessful= false};
        }
    }
}