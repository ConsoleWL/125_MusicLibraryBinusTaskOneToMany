SELECT * FROM musiclabrarybonusonetomany.playlists;
SELECT * FROM musiclabrarybonusonetomany.songs;

insert into songs(title, artist, album, ReleaseDate, Genre, Likes)
values
("Kambucha", "Sour Patches", "Not Happy Day", null, "Pop", 0),
("Pain", "Broken Legs", "First Vol", null, "Pop", 0),
("Shady", "Enimen", "Mumble", null, "Rap", 0),
("My Guitar", "Antonio Banderas", "Chico", null, "Folk", 0),
("Baby", "Barbie Girl", "Pink", null, "Pop", 0),
("Rusty Nails", "Metallica", " HangOver", null, "RocknROll", 0),
("Hollywood", "Noize MC", "One Time", null, "Rap", 0);

insert into playlists(name)
values
("Nikita's"),
("John's"),
("Breaking Up");

update songs
set playlistid = 3
where id = 7;





