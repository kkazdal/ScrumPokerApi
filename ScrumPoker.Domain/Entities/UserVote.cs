using System;

namespace ScrumPoker.Domain.Entities;

//Kullanıcıların verdiği puanları tutan tablo 
public class UserVote
{
    public int Id { get; set; }
    public int UserRoomId { get; set; }
    public UserRoom UserRoom { get; set; }
    public string Vote { get; set; }//Kullanıcının verdiği oy (Fibonacci,T-Shirt,Short Fibonacci vs.). Tüm girdiler string olacak.
}
