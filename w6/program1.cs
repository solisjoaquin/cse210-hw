/*
Program 1: Abstraction with YouTube Videos
*/

using System;
using System.Collections.Generic;

 public class Video {
     private string title;
     private string author;
     private int length;
     private List<Comment> comments;

     public Video(string title, string author, int length) {
         this.title = title;
         this.author = author;
         this.length = length;
         comments = new List<Comment>();
     }

     public string Title {
         get { return title; }
         set { title = value; }
     }

     public string Author {
         get { return author; }
         set { author = value; }
     }

     public int Length {
         get { return length; }
         set { length = value; }
     }

     public List<Comment> Comments {
         get { return comments; }
         set { comments = value; }
     }

     public int GetNumberOfComments() {
         return comments.Count;
     }
 }

public class Comment {
    private string name;
    private string text;

    public Comment(string name, string text) {
        this.name = name;
        this.text = text;
    }

    public string Name {
        get { return name; }
        set { name = value; }
    }

    public string Text {
        get { return text; }
        set { text = value; }
    }
}

class Program
{
    static void Main(string[] args)
    {
        Video video1 = new Video("We bought a 1M pizza", "MrBeast", 60200);
        video1.Comments.Add(new Comment("User 1", "Pretty amazing! "));
        video1.Comments.Add(new Comment("User 2", "Incredible"));
        video1.Comments.Add(new Comment("User 3", "Amazing!"));
        video1.Comments.Add(new Comment("User 4", "Awesome!"));
        Video video2 = new Video("The Induntrial Era", "NatGeo", 200000);
        video2.Comments.Add(new Comment("User 1", "Love it!"));
        video2.Comments.Add(new Comment("User 2", "Great!"));
        video2.Comments.Add(new Comment("User 3", "Nice!"));
        video2.Comments.Add(new Comment("User 4", "Cool!"));
        Video video3 = new Video("SpiderMan 3 Trailer", "Marvel", 12000);
        video3.Comments.Add(new Comment("User 1", "wow!"));
        video3.Comments.Add(new Comment("User 2", "Nice!"));
        video3.Comments.Add(new Comment("User 3", "Cool!"));
        video3.Comments.Add(new Comment("User 4", "Great!"));

        List<Video> videos = new List<Video>();

        videos.Add(video1);
        videos.Add(video2);
        videos.Add(video3);

        foreach (Video video in videos)
        {
            Console.WriteLine($"Title: {video.Title}");
            Console.WriteLine($"Author: {video.Author}");
            Console.WriteLine($"Length: {video.Length}");
            Console.WriteLine($"Number of Comments: {video.GetNumberOfComments()}");
            foreach (Comment comment in video.Comments)
            {
                Console.WriteLine($"User: {comment.Name}");
                Console.WriteLine($"Comment: {comment.Text}");
            }
        }
    }
}
