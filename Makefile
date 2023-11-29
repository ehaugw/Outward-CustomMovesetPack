modname = CustomMovesetPack
gamepath = /mnt/c/Program\ Files\ \(x86\)/Steam/steamapps/common/Outward/Outward_Defed
pluginpath = BepInEx/plugins
sideloaderpath = $(pluginpath)/$(modname)/SideLoader
unityassetbundles = resources/assetbundles

dependencies = CustomWeaponBehaviour TinyHelper HolyDamageManager

assemble:
	# common for all mods
	rm -f -r public
	mkdir -p public/$(pluginpath)/$(modname)
	cp -u bin/$(modname).dll public/$(pluginpath)/$(modname)/
	for dependency in $(dependencies) ; do \
		cp -u ../$${dependency}/bin/$${dependency}.dll public/$(pluginpath)/$(modname)/ ; \
	done
	
	# sideloader specific
	mkdir -p public/$(sideloaderpath)/Items
	mkdir -p public/$(sideloaderpath)/Texture2D
	mkdir -p public/$(sideloaderpath)/AssetBundles
	
	mkdir -p public/$(sideloaderpath)/Items/IronSword/Textures/mat_itm_longsword
	cp  -u  resources/icons/iron_sword.png          public/$(sideloaderpath)/Items/IronSword/Textures/icon.png
	cp  -u  resources/textures/iron_sword_gen.png   public/$(sideloaderpath)/Items/IronSword/Textures/mat_itm_longsword/_GenTex.png
	cp  -u  resources/textures/iron_sword_main.png  public/$(sideloaderpath)/Items/IronSword/Textures/mat_itm_longsword/_MainTex.png
	cp  -u  resources/textures/iron_sword_norm.png  public/$(sideloaderpath)/Items/IronSword/Textures/mat_itm_longsword/_NormTex.png
	cp  -u  resources/textures/iron_sword.xml       public/$(sideloaderpath)/Items/IronSword/Textures/mat_itm_longsword/properties.xml

	cp  -u  $(unityassetbundles)/iron_sword         public/$(sideloaderpath)/AssetBundles/iron_sword
	
publish:
	make clean
	make assemble
	rar a $(modname).rar -ep1 public/*
	
	cp -r public/BepInEx thunderstore
	mv thunderstore/plugins/$(modname)/* thunderstore/plugins
	rmdir thunderstore/plugins/$(modname)
	
	(cd ../Descriptions && python3 $(modname).py)
	
	cp -u resources/manifest.json thunderstore/
	cp -u README.md thunderstore/
	cp -u resources/icon.png thunderstore/
	(cd thunderstore && zip -r $(modname)_thunderstore.zip *)
	cp -u ../tcli/thunderstore.toml thunderstore
	(cd thunderstore && tcli publish --file $(modname)_thunderstore.zip) || true
	mv thunderstore/$(modname)_thunderstore.zip .

install:
	make assemble
	rm -r -f $(gamepath)/$(pluginpath)/$(modname)
	cp -u -r public/* $(gamepath)
clean:
	rm -f -r public
	rm -f -r thunderstore
	rm -f $(modname).rar
	rm -f $(modname)_thunderstore.zip
	rm -f resources/manifest.json
	rm -f README.md
info:
	echo Modname: $(modname)
play:
	(make install && cd .. && make play)
