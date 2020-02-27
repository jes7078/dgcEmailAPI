using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace dgcEmailAPI.Models {
  public class Emails
  {
    public int Id {get;set;}
    public string Name {get;set;}

    public string Email {get;set;}

    public string Message {get;set;}

  }
}