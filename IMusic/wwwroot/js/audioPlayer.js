// wwwroot/js/audioPlayer.js
let currentSongId = 0;
const audioPlayer = document.getElementById("audioPlayer");
const audioElement = document.getElementById("audioElement");
const playPauseButton = document.getElementById("playPauseButton");
const prevButton = document.getElementById("prevButton");
const nextButton = document.getElementById("nextButton");
const downloadButton = document.getElementById("downloadButton");
const volumeSlider = document.getElementById("volumeSlider");
const progress = document.getElementById("progress");
const currentTimeSpan = document.getElementById("currentTime");
const durationSpan = document.getElementById("duration");

// Play/Pause
playPauseButton.addEventListener("click", togglePlay);

function togglePlay() {
  if (audioElement.paused) {
    audioElement.play();
    playPauseButton.innerHTML = '<i class="fas fa-pause"></i>';
  } else {
    audioElement.pause();
    playPauseButton.innerHTML = '<i class="fas fa-play"></i>';
  }
}

// Volume control
volumeSlider.addEventListener("input", (e) => {
  audioElement.volume = e.target.value / 100;
});

// Progress bar
audioElement.addEventListener("timeupdate", updateProgress);
audioElement.addEventListener("loadedmetadata", () => {
  durationSpan.textContent = formatTime(audioElement.duration);
});

function updateProgress() {
  const progressPercent =
    (audioElement.currentTime / audioElement.duration) * 100;
  progress.style.width = progressPercent + "%";
  currentTimeSpan.textContent = formatTime(audioElement.currentTime);
}

function formatTime(seconds) {
  const minutes = Math.floor(seconds / 60);
  const remainingSeconds = Math.floor(seconds % 60);
  return `${minutes}:${remainingSeconds.toString().padStart(2, "0")}`;
}

// Download button
downloadButton.addEventListener("click", () => {
  if (currentSongId > 0) {
    window.location.href = `/Song/Download/${currentSongId}`;
  }
});

// Load and play song
function loadAndPlaySong(songId) {
  currentSongId = songId;
  audioPlayer.style.display = "block";

  fetch(`/Song/GetSongInfo/${songId}`)
    .then((response) => response.json())
    .then((data) => {
      document.getElementById("songTitle").textContent = data.title;
      document.getElementById("artistName").textContent = data.artist;
      document.getElementById("songImage").src = data.imageUrl;

      audioElement.src = `/Song/Play/${songId}`;
      audioElement.play();
      playPauseButton.innerHTML = '<i class="fas fa-pause"></i>';
    })
    .catch((error) => console.error("Error:", error));
}

// Export function for global use
window.loadAndPlaySong = loadAndPlaySong;
