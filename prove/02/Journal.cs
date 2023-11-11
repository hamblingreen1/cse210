using System;

class Journal
{
	// Instantiate entries list
	public List<Entry> Entries { get; } = new List<Entry>();

	// Add entry to journal
	public void AddEntry(Entry entry)
	{
		Entries.Add(entry);
	}

	// Replace all entries with list passed
	public void ReplaceEntries(List<Entry> entries)
	{
		Entries.Clear();
		Entries.AddRange(entries);
	}
}

