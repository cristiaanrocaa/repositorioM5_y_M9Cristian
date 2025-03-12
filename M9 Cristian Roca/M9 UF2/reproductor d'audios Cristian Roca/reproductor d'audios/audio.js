document.addEventListener("DOMContentLoaded", () => {
    const audioPlayers = document.querySelectorAll('.audio-player');

    audioPlayers.forEach((audioPlayer, index) => {
        const playButton = audioPlayer.parentElement.querySelector('.play');
        const pauseButton = audioPlayer.parentElement.querySelector('.pause');
        const stopButton = audioPlayer.parentElement.querySelector('.stop');
        const volumeSlider = audioPlayer.parentElement.querySelector('.volume');
        const speedSelector = audioPlayer.parentElement.querySelector('.speed');
        const progressBar = audioPlayer.parentElement.querySelector('.progress');

        playButton.addEventListener("click", () => audioPlayer.play());
        pauseButton.addEventListener("click", () => audioPlayer.pause());
        stopButton.addEventListener("click", () => {
            audioPlayer.pause();
            audioPlayer.currentTime = 0;
        });

        volumeSlider.addEventListener("input", () => {
            audioPlayer.volume = volumeSlider.value;
        });

        speedSelector.addEventListener("change", () => {
            audioPlayer.playbackRate = speedSelector.value;
        });

        audioPlayer.addEventListener("timeupdate", () => {
            progressBar.value = (audioPlayer.currentTime / audioPlayer.duration) * 100;
        });

        progressBar.addEventListener("input", () => {
            audioPlayer.currentTime = (progressBar.value / 100) * audioPlayer.duration;
        });
    });
});
