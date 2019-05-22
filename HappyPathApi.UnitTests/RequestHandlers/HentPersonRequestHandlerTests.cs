using HappyPathApi.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace HappyPathApi.RequestHandlers
{
    public class HentPersonRequestHandlerTests
    {
        private readonly HentPersonRequestHandler _sut;

        public HentPersonRequestHandlerTests()
        {
            _sut = new HentPersonRequestHandler();
        }

        [Fact]
        public async Task Getting_person_with_id_4_throws_entity_not_found_exception()
        {
            await Assert.ThrowsAsync<EntityNotFoundException>(()=>_sut.Handle(new Requests.HentPersonRequest(4), CancellationToken.None));
        }

        [Fact]
        public async Task Getting_person_with_id_1_throws_DB2UnavailableException()
        {
            await Assert.ThrowsAsync<DB2UnavailableException>(() => _sut.Handle(new Requests.HentPersonRequest(1), CancellationToken.None));
        }


        [Fact]
        public async Task Getting_person_with_id_69_returns_that_person()
        {
            var result = await _sut.Handle(new Requests.HentPersonRequest(69), CancellationToken.None);
            Assert.Equal(69, result.Id);
        }
    }
}
