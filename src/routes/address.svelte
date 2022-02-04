<script>
    async function getRandomAddress() {
        const response = await fetch("/api/NextAddress");
        
        //TODO: remove it
        if (response.redirected) {
            window.location = response.url;
            return;
        }
        return await response.json();
    }

    let addressPromise = getRandomAddress();
</script>

<h1>And your next postcard goes to...</h1>

<div class="row justify-content-md-center">
    <div class="card">
        {#await addressPromise}
            <p>Fetching data hang on...</p>
        {:then recipient}
            <div id="recipient-card" class="card-body">
                <h5 class="card-title">{recipient.name}</h5>
                <p class="card-text" />
                <pre>{recipient.address}</pre>
            </div>
        {/await}
    </div>
</div>
