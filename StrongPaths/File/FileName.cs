namespace ktsu.io.StrongPaths
{
	public sealed record class FileName : StrongPath<FileName>
	{
		/// <summary>
		/// Returns the last period delimited segment of the FileName including the leading period, or empty if the FileName has no extension
		/// </summary>
		public FileExtension Extension => (FileExtension)((string?)(Value.Split('.').LastOrDefault()?.Prepend('.')) ?? string.Empty);

		/// <summary>
		/// Returns all trailing period delimited segments of the FileName including the leading period, or empty if the FileName has no extensions
		/// </summary>
		public FileExtension FullExtension => (FileExtension)((string?)(Value.Split('.', 2).Skip(1).FirstOrDefault()?.Prepend('.')) ?? string.Empty);

		/// <summary>
		/// Returns the FileName with a single suffix removed from the end, or the original FileName if the suffix was not found
		/// </summary>
		/// <param name="suffix">The suffix to remove from the end of the FileName</param>
		/// <returns>The FileName with a suffix removed from the end, or the original FileName if the suffix was not found</returns>
		public FileName RemoveSuffix(string suffix) => Value.EndsWith(suffix, StringComparison.Ordinal) ? (FileName)Value[..^(suffix?.Length ?? 0)] : this;

		/// <summary>
		/// Returns the FileName with the first suffix found removed from the end, or the original FileName if no suffix was not found
		/// </summary>
		/// <param name="suffixes">The suffixes to attempt to remove from the end of the FileName</param>
		/// <returns>The FileName with a suffix removed from the end, or the original FileName if the suffix was not found</returns>
		public FileName RemoveSuffix(params string[] suffixes) => RemoveSuffix(suffixes);

		/// <summary>
		/// Returns the FileName with the first suffix found removed from the end, or the original FileName if no suffix was not found
		/// </summary>
		/// <param name="suffixes">The suffixes to attempt to remove from the end of the FileName</param>
		/// <returns>The FileName with a suffix removed from the end, or the original FileName if the suffix was not found</returns>
		public FileName RemoveSuffix(IEnumerable<string> suffixes)
		{
			foreach (string suffix in suffixes ?? Array.Empty<string>())
			{
				var result = RemoveSuffix(suffix);
				if (result != this)
				{
					return result;
				}
			}

			return this;
		}
	}
}
