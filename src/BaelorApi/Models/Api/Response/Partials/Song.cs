﻿using Newtonsoft.Json;
using System;

namespace BaelorApi.Models.Api.Response.Partials
{
	public class Song
	{
		[JsonProperty("index")]
		public int Index { get; set; }

		[JsonProperty("slug")]
		public string Slug { get; set; }

		[JsonProperty("title")]
		public string Title { get; set; }

		[JsonProperty("length")]
		public TimeSpan Length { get; set; }

		[JsonProperty("writers")]
		public string[] Writers { get; set; }

		[JsonProperty("producers")]
		public string[] Producers { get; set; }

		[JsonProperty("album", NullValueHandling = NullValueHandling.Ignore)]
		public Album Album { get; set; }

		[JsonProperty("lyric_slug")]
		public string LyricSlug { get; set; }

		public static Song Create(Database.Song song, bool includeAlbum)
		{
			return new Song
			{
				Writers = song.Writers.Split(','),
				Producers = song.Producers.Split(','),
				Length = TimeSpan.FromSeconds(song.LengthSeconds),
				Index = song.Index,
				Title = song.Title,
				Slug = song.Slug,
				LyricSlug = song.LyricId == null ? null : song.Slug,
				Album = includeAlbum ? Album.Create(song.Album, false) : null
			};
		}
	}
}