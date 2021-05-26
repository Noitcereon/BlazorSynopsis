// In development, always fetch from the network and do not enable offline support.
// This is because caching would make development more difficult (changes would not
// be reflected on the first load after each change).
console.log({ self });

self.addEventListener('install', (e) => {
    console.log("Service Worker: installed");
})

self.addEventListener('activated', (e) => {
    console.log("Service Worker: activated");
    // waitUntil is an ExtendableEvent (event lifespan extension)
    //e.waitUntil(
    //    caches.keys().then(cacheNames => {
    //        return Promise.all()
    //    }) 
    //)
})

self.addEventListener('fetch', (e) => {
    //console.log("Service Worker: intercepted a fetch call");
    //console.log(e.request);
})
