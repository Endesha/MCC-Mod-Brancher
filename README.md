Sorry folks, just realised the game can't handle symlink files, can deal with symlink folders no problem.
Could make a version which copies files etc, but might as well use explorer for that.


To uninstall:

In game root directory: delete folders with links (that you backed-up)
go into mods/originals/ copy the directories,
go to game root and paste

delete mods

done :)


sorry for wasting your time ;/









# MCC Mod Brancher
### About:

![](https://i.imgur.com/K7cRA0O.png)![enter image description here](https://i.imgur.com/CjpDql1.png)![enter image description here](https://i.imgur.com/iJAasiL.png)

MCC Mod Brancher is a tool which allows you to create multiple "branches" of the game folders for the [Master Chief Collection](https://store.steampowered.com/app/976730/Halo_The_Master_Chief_Collection/). After creating a branch, you can easily swap which branch is "currently active".

By branching the whole game folder, it allows you to easily have "complete"  versions of the game, without having to constantly swap individual files.

### Links:

- #### [Download](https://github.com/Endesha/MCC-Mod-Brancher/releases)
- #### [Tutorial](https://github.com/Endesha/MCC-Mod-Brancher/blob/master/Tutorial.md)

### How it works:
When you branch a directory, rather than copying all files, the branch files instead refer to the original files using [symlinks](https://en.wikipedia.org/wiki/Symbolic_link).

When browsing a branch, you can open a selected file in various editors; if the chosen file hasn't been changed since the original, it will automatically replace the symlink with a copy of the original file. 

In the branch browser, you can also drag and drop files to replace.

### Features:
  - Easy to use
  - Live hot-swapping (not in level, but in game)
  - Built-in file branch browser
  - Load files in [Assembly](https://github.com/XboxChaos/Assembly) or [Zeta](https://github.com/MarkOfBlam/zeta)
  - Temporary backup & restore for individual files
  - Checks if updates available


### Potential Future Features:
  - Someone (probs not me) could look at generating & applying patches against original files. (In my eyes) Would require to checksum all original game files to verify patch will work. Look at [mccLaunch](https://github.com/brushtool/mccLaunch) for a project which offers this already.
  - Drag n drop files whilst searching

---

Enjoy!
