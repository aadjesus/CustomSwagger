let links = Array.from(document.head.getElementsByTagName("link"))
	.filter(f => f.getAttribute('rel') === 'icon');

for (let link of links) {
	link.href = '/swagger-ui/favicon.ico';
}