<script>
	import { page } from "$app/stores";

	async function getUserInfo() {
		const response = await fetch("/.auth/me");
		const payload = await response.json();
		const { clientPrincipal } = payload;
		return clientPrincipal;
	}

	let promise = getUserInfo();
</script>

<header>
	<nav class="navbar navbar-expand-lg navbar-light bg-light">
		<div class="container-fluid">
			<!-- svelte-ignore a11y-invalid-attribute -->
			<a sveltekit:prefetch class="navbar-brand" href="/"
				>Postcard Exchange</a
			>
			<button
				class="navbar-toggler"
				type="button"
				data-bs-toggle="collapse"
				data-bs-target="#navbarSupportedContent"
				aria-controls="navbarSupportedContent"
				aria-expanded="false"
				aria-label="Toggle navigation"
			>
				<span class="navbar-toggler-icon" />
			</button>
			<div class="collapse navbar-collapse" id="navbarSupportedContent">
				<ul class="navbar-nav me-auto mb-2 mb-lg-0">
					<li class="nav-item">
						<a
							sveltekit:prefetch
							class="nav-link active"
							aria-current="page"
							href="/">Home</a
						>
					</li>
				</ul>
			</div>
			<ul class="navbar-nav me-auto mb-2 mb-lg-0">
				<li class="nav-item" id="user-info">
					{#await promise then clientPrincipal}
						{#if (clientPrincipal && clientPrincipal.userDetails)}
							<a
								class="nav-link active"
								aria-current="page"
								href="/.auth/logout">{clientPrincipal.userDetails}</a
							>
						{:else}
							<a class="nav-link active btn btn-secondary" aria-current="page" href="/.auth/login/github">Login</a>
						{/if}
					{/await}
				</li>
			</ul>
		</div>
	</nav>
</header>
