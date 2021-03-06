﻿using System.Collections.Generic;
using BaelorApi.Models.Error.Enums;

namespace BaelorApi.Extentions
{
	public static class EnumExtentions
	{
		/// <summary>
		/// Dictionary of friendly error status messages.
		/// </summary>
		private static readonly Dictionary<ErrorStatus, string> ErrorStatusFriendly = new Dictionary<ErrorStatus, string>
		{
			// Server Stuff
			{ ErrorStatus.GenericServerError, "generic_server_error" },

			// Album Stuff
			{ ErrorStatus.InvalidAlbumSlug, "invalid_album_slug" },
			{ ErrorStatus.AlbumAlreadyExists, "album_already_exists" },

			// Song Stuff
			{ ErrorStatus.InvalidSongSlug, "invalid_song_slug" },
			{ ErrorStatus.SongAlreadyExists, "song_already_exists" },

			// Image Stuff
			{ ErrorStatus.InvalidImageId, "invalid_image_id" },

			// Data Validation
			{ ErrorStatus.DataValidationFailed, "data_validation_failed" },

			// Authentication
			{ ErrorStatus.RequestRequiredAuthentication, "request_requires_authentication" },
			{ ErrorStatus.InvalidApiKey, "invalid_api_key" },
			{ ErrorStatus.RevokedApiKey, "revoked_api_key" },
			{ ErrorStatus.InsufficientPrivileges, "insufficient_privileges" },

			// Rate Limit
			{ ErrorStatus.RateLimitExceeded, "rate_limit_exceeded" },

			// Lyrics
			{ ErrorStatus.SongDoesntContainLyrics, "song_doesnt_contain_lyrics" },
			{ ErrorStatus.SongAlreadyContainsLyrics, "song_already_contains_lyrics" },
			{ ErrorStatus.UnableToCreateLyrics, "unable_to_create_lyrics" },

			// Demo shit
			{ ErrorStatus.DemoApiKeyNotAcceptable, "demo_api_key_not_acceptable" }
		};

		/// <summary>
		/// Get a friendly error message from a <see cref="ErrorStatus"/>.
		/// </summary>
		/// <param name="value">The <see cref="ErrorStatus"/> in question.</param>
		public static string GetDisplayDescription(this ErrorStatus value)
		{
			if (ErrorStatusFriendly.ContainsKey(value))
				return ErrorStatusFriendly[value];

			throw new KeyNotFoundException(value.ToString());
		}
	}
}