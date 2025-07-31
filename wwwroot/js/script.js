let url = document.querySelector('input[name="url"]');
let form = document.querySelector("form");
let button = document.querySelector('button[type="submit"]');

form.addEventListener("submit", (e) => {
  e.preventDefault();

  let urlValue = url.value.trim();
  getShortenedUrl(urlValue);
});

function getShortenedUrl(urlValue) {
  if (!urlValue) {
    alert("Please enter a valid URL");
    return;
  }

  fetch("api/shorten", {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify({ Url: urlValue }),
  })
    .then((response) => {
      if (!response.ok) {
        console.log(response.status + JSON.stringify(response.body));
        throw new Error("Network response was not ok");
      }
      return response.json();
    })
    .then((data) => {
      alert("Shortened URL: " + data.shortUrl);
    })
    .catch((error) => {
      console.error("There was a problem with the fetch operation:", error);
    });
}
